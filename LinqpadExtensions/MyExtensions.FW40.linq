<Query Kind="Program" />

void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	// Write custom extension methods here. They will be available to all queries
	public static string SayHello(this char ch)
	{
		return string.Concat("Hello " , ch);
	}
	
}

// You can also define non-static classes, enums, etc.