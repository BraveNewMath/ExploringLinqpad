<Query Kind="Program">
  <Connection>
    <ID>b2597227-862c-4235-9394-d50f757c73e7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference Relative="..\Console1\Console1\bin\Debug\Console1.exe">C:\projects\esri\Presentations\Linqpad\Console1\Console1\bin\Debug\Console1.exe</Reference>
  <Reference Relative="..\Console1\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll">C:\projects\esri\Presentations\Linqpad\Console1\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll</Reference>
  <Reference Relative="..\Console1\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll">C:\projects\esri\Presentations\Linqpad\Console1\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Data.DataSetExtensions.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.Data.dll</Reference>
  <NuGetReference>HtmlAgilityPack</NuGetReference>
  <Namespace>HtmlAgilityPack</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.Entity</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
</Query>

void Main()
{
	//var hd = new HtmlDocument();
	//hd.l("http://example.com");
	//hd.Dump();
	var hw = new HtmlWeb();
	
	HtmlDocument doc = null;
	
	doc = LINQPad.Util.Cache(()=> 
	{
		"Fetching data...".Dump();
		return hw.Load("http://localhost.esri.com:8080");
	}, "The data");
	//hw.ResponseUri.Host.Dump("ResponseUri.Host");
	//doc.DocumentNode.OuterHtml.Dump();
	
	
	doc.DocumentNode.Descendants("title").SingleOrDefault().InnerHtml.Dump("Title");
	doc.DocumentNode.Descendants("link").Where (dn => dn.Attributes["rel"].Value=="canonical")
	.Select (dn => dn.GetAttributeValue("href", ""))
	.FirstOrDefault()
	.Dump("canonical");
	doc.DocumentNode.SelectNodes("//a")
		.Select (dn => new {
			dn.Line, dn.LinePosition, dn.InnerText, href=dn.GetAttributeValue("href", "")
		})
		.Dump();
	
}

// Define other methods and classes here