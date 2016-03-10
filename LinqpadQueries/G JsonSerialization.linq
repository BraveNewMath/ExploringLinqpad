<Query Kind="Program">
  <NuGetReference>mongocsharpdriver</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
</Query>

void Main()
{
	var foo1 = new Foo("joe", "baseball", new Foo("joe", "baseball super star", null));
	foo1.Dump();
	
	JsonConvert.SerializeObject(foo1, Newtonsoft.Json.Formatting.None).Dump();
	JsonConvert.SerializeObject(foo1, Newtonsoft.Json.Formatting.Indented).Dump();
	
}

class Foo
{
	public Foo(string name, string hobby, Foo innerFoo)
	{
		Name = name;
		Hobby= hobby;
		InnerFoo = innerFoo;
	}
	public string Name { get; set; }
	public string Hobby { get; set; }
	public Foo InnerFoo{get;set;}
	
}