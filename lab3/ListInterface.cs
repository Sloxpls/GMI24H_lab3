namespace LinkedListProject;

public interface IListInterface<T> {
    void Add(T item, int index);
    bool Remove(int index);
    int Size();
    T Get(int index);
}
