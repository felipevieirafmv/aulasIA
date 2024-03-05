using System.Linq;

namespace AIDiscrete.Collections;

public class WeightedNode<T> : INode<T>
{
    public T Value { get; set; }
    public List<Edge<T>> Neighbours { get; set; }
    public int Connections => Neighbours.Count;

    public WeightedNode(T value = default(T), List<Edge<T>> neighbours = null!)
    {
        this.Value = value;
        this.Neighbours = neighbours ?? new List<Edge<T>>();
    }

    public WeightedNode<T> AddNode(Edge<T> edge)
    {
        this.Neighbours.Add(edge);

        return this;
    }

    public WeightedNode<T> AddNode(WeightedNode<T> node, float weight)
    {
        this.Neighbours.Add(new Edge<T>(node, weight));

        return this;
    }

    public WeightedNode<T> RemoveNode(Edge<T> edge)
    {
        this.Neighbours.Remove(edge);
        
        return this;
    }

    public WeightedNode<T> RemoveNode(WeightedNode<T> node)
    {
        Neighbours.RemoveAll(edge => edge.Node == node)
        
        return this;
    }
}
