namespace AIDiscrete.Collections;

public class Edge
{
    public WeightedNode<T> Node { get; set; }
    public float Weight { get; set; }

    public Edge(WeightedNode<T> node, float weight)
    {
        Node = node;
        Weight = weight;
    }
}