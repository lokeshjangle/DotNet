interface IStackReader<out T>
{
    T Pop();
    bool Empty();
}

interface IStackWriter<in T>
{
    void Push(T item);
}

class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
{
    class Node
    {
        internal V Value;
        internal Node Below;
    }

    private Node top;

    public void Push(V item)
    {
        top = new Node { Value = item, Below = top};
    }

    public V Pop()
    {
        V item = top.Value;
        top = top.Below;
        return item;
    }

    public bool Empty()
    {
        return top is null;
    }
}
