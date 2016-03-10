<Query Kind="Expression">
  <Output>DataGrids</Output>
</Query>

"hello world"
	.AsEnumerable()
	.Select (x => 
		x.SayHello()
	)