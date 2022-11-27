using BoyerMooreStringSearchAlgorithm;

const string text = "foo bar baz qux quux corge grault garply";
Console.WriteLine("Initial text data:");
Console.WriteLine(text);
    
var tree = SearchEngine.Prepare(text);
foreach (var testItem in new List<string>
         {
             "foo", "f", "123", "foo1", "Foo"
         })
{
    Console.WriteLine($"Test case: {testItem}");
    var result = SearchEngine.Check(tree, testItem);
    Console.WriteLine(result ? "Contains" : "Not contains");
}
