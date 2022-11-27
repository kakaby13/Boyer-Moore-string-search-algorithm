namespace BoyerMooreStringSearchAlgorithm;

public static class SearchEngine
{
    public static Node Prepare(string rawData)
    {
        var separatedData = rawData.Split(' ').ToList();

        var rootNode = new Node(' ');
        
        foreach (var item in separatedData)
        {
            Process(rootNode, item);
        }

        return rootNode;
    }

    public static bool Check(Node node, string dataString)
    {
        if (dataString.Length == 0)
        {
            return true;
        }
        
        var currentCharacter = dataString[0];
        if (node.Children.All(c => c.Character != currentCharacter))
        {
            return false;
        }
        
        var substring = dataString.Substring(1, dataString.Length - 1);
        return Check(node.Children.Single(c => c.Character == currentCharacter), substring);
    }

    private static void Process(Node node, string dataString)
    {
        var currentCharacter = dataString[0];
        if (!node.Children.Select(c => c.Character).ToList().Contains(currentCharacter))
        {
            node.Children.Add(new Node(currentCharacter));
        }

        var substring = dataString.Substring(1, dataString.Length - 1);
        if (substring.Length > 0)
        {
            Process(node.Children.Single(c => c.Character == currentCharacter), substring);
        }
    }
}
