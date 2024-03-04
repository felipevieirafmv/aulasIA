namespace AIDiscrete.Collections;

public class Node<T> : INode<T>
{
    public T Value { get; set; }
    public List<Node<T>> Neighbours { get; set; }
    public int Connections => Neighbours.Count;

    public Node(T value = default(T), List<Node<T>> neighbours = null!)
    {
        this.Value = value;
        this.Neighbours = neighbours ?? new List<Node<T>>();

        foreach(var neighbour in Neighbours)
            neighbour.Neighbours.Add(this);
    }

    public Node<T> AddNode(Node<T> node)
    {
        this.Neighbours.Add(node);
        node.Neighbours.Add(this);

        return this;
    }

    public Node<T> RemoveNode(Node<T> connection)
    {
        this.Neighbours.Remove(connection);
        connection.Neighbours.Remove(this);

        return this;
    }
}