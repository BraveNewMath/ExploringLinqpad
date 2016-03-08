<Query Kind="Statements">
  <Connection>
    <ID>b2597227-862c-4235-9394-d50f757c73e7</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//find number of orders users have made

//Customers.Dump();

Customers
	.Where (c => c.Orders.Any ()  )
	//.Where(x=> x.CustomerID=="ALFKI")
	.Select (c => new 
	{
		c.ContactName, 
		OrderInfo = c.Orders.Select (o => new 
		{
		  o.OrderDate,
		  o.OrderDetails,
		  Total=o.OrderDetails.Sum (od => (od.UnitPrice*od.Quantity) -(decimal)od.Discount
			)
		})
	})
	//.ToList()
	.Select (c => new 
	{
		c.ContactName,
		AverageOrderPrice =  c.OrderInfo.Average (oi => oi.Total),
		//c.OrderInfo
	})
	.OrderByDescending (c => c.AverageOrderPrice)
	.Dump();