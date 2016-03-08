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
  <Namespace>System.Data</Namespace>
  <Namespace>System.Data.Entity</Namespace>
  <Namespace>System.Data.SqlClient</Namespace>
</Query>

void Main()
{
	var myclass1 = new Console1.MyClass();
	
	
	//Debugger.Launch();
	var helloString = myclass1.SayHello();
	helloString.Dump();
	
	//myclass1.GetCustomerNames().Dump("From Program", 1);
	
//	 //var ctx= this;
//	 //var customerNames = ctx.
//	 	Customers
//			.Where (c => c.ContactName.StartsWith("b"))
//	 	//.Select (c => string.Concat(c.ContactName, " @ ", c.CompanyName))
//	 	.Dump();
}

// Define other methods and classes here