namespace LinkedListProject;

public class ListReferencedBased<T> : IListInterface<T> {
    private Node<T>? _head;
    private int _numItems;

    public ListReferencedBased() {
        _head = null;
        _numItems = 0;
    }

    public void Add(T item, int index) {
        if (index < 1 || index > _numItems + 1) {
            throw new ListIndexOutOfBoundsException("Index out of bounds");
        }

        Node<T> newNode = new Node<T>(item);
        if (index == 1) {
            newNode.Next = _head;
            _head = newNode;
        }
        else {
            Node<T>? current = _head;
            for (int i = 1; i < index - 1; i++) {
                current = current!.Next;
            }

            newNode.Next = current!.Next;
            current.Next = newNode;
        }
        _numItems++;
    }

    public bool Remove(int index) {
        if (index < 1 || index > _numItems || _head == null)
            return false;

        if (index == 1) {
            _head = _head.Next;
        }
        else {
            Node<T>? current = _head;
            for (int i = 1; i < index - 1; i++) {
                current = current!.Next;
            }

            if (current!.Next != null) {
                current.Next = current.Next.Next;
            }
        }
        _numItems--;
        return true;
    }

    public int Size() {
        return _numItems;
    }

    public T Get(int index) {
        if (index < 1 || index > _numItems)
            throw new ListIndexOutOfBoundsException("Index out of bounds");
        Node<T>? current = _head;
        for (int i = 1; i < index; i++) {
            current = current!.Next;
        }
        return current!.Data;
    }
}

