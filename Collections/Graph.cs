namespace AIDiscrete.Collections;

public class Graph<T>
{
    public List<GraphNode<T>> Nodes { get; set; }

    public Graph(List<GraphNode<T>> nodes = null!)
    {
        Nodes = nodes ?? new List<GraphNode<T>>();
    }
}
