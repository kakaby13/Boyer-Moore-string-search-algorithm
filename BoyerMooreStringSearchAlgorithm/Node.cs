namespace BoyerMooreStringSearchAlgorithm;

public class Node
{
    public Node(char character)
    {
        Character = character;
        Children = new List<Node>();
    }

    public char Character { get; set; }
    
    public List<Node> Children { get; set; }
}
