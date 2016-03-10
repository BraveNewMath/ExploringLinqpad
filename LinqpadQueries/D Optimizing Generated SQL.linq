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
	//you could use SQL Profile to trace the SQL... or LINQPAD
	var findProductContaining = "";//"mix";
	//GetProductsWithCategories(findProductContaining);
	GetProductsWithCategories2(findProductContaining);
	
	
//	var myclass1 = new Console1.MyClass();
//	myclass1.GetProducts(findProductContaining ).Dump("From myclass1");
}

void GetProductsWithCategories(string productNameContains)
{
	productNameContains.Dump();
//	Products
//		.Where (p => p.ProductName.Contains(productNameContains))
//		.Dump();

	Products
		.Where (p => p.ProductName.Contains(productNameContains))
		.GroupBy (p => p.Category.CategoryName)
		.Select (p => new Console1.Models.CategoryWithProduct
		{
			Name = p.Key,
			Products = p.Select (x => new Console1.Models.Product
			{
				 ProductName= x.ProductName,
				Price = x.UnitPrice
				
			})
		})
		.Dump("GetProductsWithCategories");
}

void GetProductsWithCategories2(string productNameContains)
{
	productNameContains.Dump();
//	Products
//		.Where (p => p.ProductName.Contains(productNameContains))
//		.Dump();

	Categories
		.Where (c => c.Products.Any (p => p.ProductName.Contains(productNameContains)))
		.Select (c => new Console1.Models.CategoryWithProduct {
		   Name= c.CategoryName, 
		   Products = c.Products.Where (p => p.ProductName.Contains(productNameContains))
		   	.Select (p => new Console1.Models.Product
			{
				ProductName= p.ProductName,
				Price= p.UnitPrice
			})
		}).Dump("GetProductsWithCategories2");
}