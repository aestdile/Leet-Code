public class MyStack {
    Queue<int> q;
    public MyStack() {
        q = new Queue<int>();
    }
    
    public void Push(int x) {
        q.Enqueue(x);
        int Count = q.Count-1;
        while(Count > 0) {
            q.Enqueue(q.Dequeue());
            Count--;
        }   
    }

    public int Pop() {
        return q.Count > 0 ? q.Dequeue() : -1;
    }
    
    public int Top() {
        return q.Count > 0 ? q.Peek() : -1;
    }
    
    public bool Empty() {
        return (q.Count == 0);
    }
}
