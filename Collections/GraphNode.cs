namespace AIDiscrete.Collections;

public class GraphNode<T> : INode<T>
{
    public T Value { get; set; }
    public List<GraphNode<T>> Neighbours { get; set; }
    public int Connections => Neighbours.Count;

    public GraphNode(T value = default(T), List<GraphNode<T>> neighbours = null!)
    {
        this.Value = value;
        this.Neighbours = neighbours ?? new List<GraphNode<T>>();

        foreach(var neighbour in Neighbours)
            if(!neighbour.Neighbours.Contains(this))
                neighbour.Neighbours.Add(this);
    }

    public GraphNode<T> AddNode(GraphNode<T> graphNode)
    {
        if(!Neighbours.Contains(graphNode))
            this.Neighbours.Add(graphNode);
        if(!graphNode.Neighbours.Contains(this))
            graphNode.Neighbours.Add(this);

        return this;
    }

    public GraphNode<T> RemoveNode(GraphNode<T> connection)
    {
        this.Neighbours.Remove(connection);
        connection.Neighbours.Remove(this);

        return this;
    }
}