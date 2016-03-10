<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	//given a date range, show me what that range will look like in these languages
	var languages =  new List<string>{"de-DE", "en", "es-ES", "es-MX", "fr-FR", "it-IT", "pt-BR", "sv-SE"};
	//here are the date ranges
	var dateRanges =new List<DateRange>{
		new DateRange {Tag="A - Single Day", Start=new DateTime(2016, 1, 2), End=null},
		new DateRange {Tag="B - Multi day, same month", Start=new DateTime(2016, 1, 2), End=new DateTime(2016, 1, 9)},
		new DateRange {Tag="C - Multi day, different months, same year", Start=new DateTime(2016, 1, 2), End=new DateTime(2016, 2, 9)},
		new DateRange {Tag="D - Multi day, different years", Start=new DateTime(2016, 12, 9), End=new DateTime(2017, 1, 5)},
	};
	
	//first we use select many to generate a cartesian join
	languages
		.SelectMany (dr=> dateRanges, (l,dr )=> new {l, dr}) //this is the cartesian join
		.Select (x => new {
			x.l, 
			x.dr.Tag,
			x.dr.Start, 
			x.dr.End, 
			CustomDateRange=GetLocalizedEventDateRange(x.dr.Start, x.dr.End, x.l).Replace("&ndash;", "-")
			})
			//.Where (x => x.Tag.StartsWith("C"))
		.Dump();

}

class DateRange
{
	public string Tag {get;set;}
	public DateTime? Start { get; set; }
	public DateTime? End { get; set; }
}

  private static string GetMediumDateFormat(string longDateFormat, string cultureName)
        {
            var result = longDateFormat;
            if (cultureName == "sv-SE")
                result = result.Replace("'den '", "");

            if (longDateFormat.Contains("dddd, "))
                result = result.Replace("dddd, ", "");

            if (longDateFormat.Contains("dddd "))
                result = result.Replace("dddd ", "");

            if (result.Contains("dd"))
                result = result.Replace("dd", "d");

            if (result.Contains(" de "))
                result = result.Replace("' de '", " ");
            return result;
        }

 public static string GetLocalizedMediumDate(DateTime? date, string language)
	    {
	        var result = "";
	        if (date.HasValue)
	        {
	            var culture = new CultureInfo(language);
	            var dateFormat = GetMediumDateFormat(culture.DateTimeFormat.LongDatePattern, culture.Name);
	            result = date.Value.ToString(dateFormat, culture);
	        }
	        return result;
	    }

public string GetLocalizedEventDateRange(DateTime? StartDate, DateTime? EndDate, string language)
        {
            var sRange = String.Empty;
            var culture = new CultureInfo(language);

            // Only return a date if at least the Start Date is set.
            if (StartDate.HasValue)
            {
                var oStartDate = StartDate.Value;
                var oEndDate = EndDate.HasValue ? EndDate.Value : oStartDate;
                string monthDayFormat = language=="en"? "MMMM d": 
					language=="de-DE"? "d. MMMM":"d MMMM";
                // Case 1 -> Not End Date. For instance: September 15, 2014
                if (oStartDate.Equals(oEndDate))
                {//A
                        sRange = GetLocalizedMediumDate(oStartDate, language);
                }
                // Case 2 -> Same year for both (Start and End Date) 
                else if (oStartDate.Year == oEndDate.Year)
                {
                    if (oStartDate.Month == oEndDate.Month)
                    {//B: same month. For instance: September 15-17, 2014
                            sRange = String.Format("{0} &ndash; {1}, {2}",
                                                   oStartDate.ToString(monthDayFormat, culture),
                                                   oEndDate.Day,
                                                   oStartDate.Year);
                     
                    }
                    else
                    {
                        //C: different month. For instance: September 30 - October 17, 2014
                       sRange = String.Format("{0} &ndash; {1}",
                                              oStartDate.ToString(monthDayFormat, culture),
                                              //oEndDate.ToString(dayFormat, culture)
											  GetLocalizedMediumDate(oEndDate, language)
											  );
                      
                    }
                }
                //D Case 3 -> Different year for both. For instance: December 31, 2013 - January 01, 2014
                else
                {
                   sRange = String.Format("{0} &ndash; {1}",
								GetLocalizedMediumDate(oStartDate, language),
								GetLocalizedMediumDate(oEndDate, language));
                }
            }

            return sRange;
        }


void ShowDateFormats(List<String> languages){
	var date = DateTime.Now;
	languages.Select (l => new {
		Lang=l,
		culture = new CultureInfo(l)
	}).Select (l => new {
		l.culture.Name,
		l.culture.DateTimeFormat.LongDatePattern,
		MyDateFormat = GetDateFormat(l.culture.DateTimeFormat.LongDatePattern, l.culture.Name),
		l.culture.DateTimeFormat.ShortDatePattern,
		d_shortDate =  date.ToString("d", l.culture),
		D_longDate =  date.ToString("D", l.culture),
		MyFormat = date.ToString(GetDateFormat(l.culture.DateTimeFormat.LongDatePattern, l.culture.Name), l.culture),
		g_generalDate1 =  date.ToString("g", l.culture),
		m =  date.ToString("m", l.culture),
		y =  date.ToString("y", l.culture),
		dd = date.ToString("dd", l.culture),
		mm = date.ToString("mm", l.culture),
		yy = date.ToString("yy", l.culture),
	}) .Dump();
}

string GetDateFormat(string longDateFormat, string cultureName)
{
	var result = longDateFormat;
	if (cultureName=="sv-SE")
		result = result.Replace("'den '", "");
	
	if (longDateFormat.Contains("dddd, "))
		result = result.Replace("dddd, ", "");
	
	if (longDateFormat.Contains("dddd "))
		result = result.Replace("dddd ", "");
	
	if (result.Contains("dd"))
		result = result.Replace("dd", "d");
		
	if (result.Contains(" de "))
		result = result.Replace("' de '", " ");
	return result;
}
