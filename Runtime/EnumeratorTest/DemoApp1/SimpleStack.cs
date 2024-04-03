class SimpleStack<V>
{
    class Node
    {
        internal V Value;
        internal Node Below;

        internal Node Seek(int offset)
        {
            Node target = this;
            for(int i = 0; i < offset; ++i)
                target = target.Below;
            return target;
        }
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

    //in order to enable standard iteration, a type must support GetEnumerator()
    //method whose return type supports Current property and MoveNext() method
    //as declared in System.Collections.Generic.IEnumerator<E> interface
    public IEnumerator<V> GetEnumerator()
    {
        for(Node n = top; n != null; n = n.Below)
        {
            //the 'yield return' statement iteratively passes target values to 
            //the caller of the method through an auto-generated implementation of 
            //IEnumerator<E> interface specified as return type of that method
            yield return n.Value;
        }
    }

    //an 'indexer' is a parameterized property which provides access to 
    //the data within 'this' instance using array-like syntax
    public V this[int index]
    {
        get { return top.Seek(index).Value; }
        set { top.Seek(index).Value = value; }
    }
}
