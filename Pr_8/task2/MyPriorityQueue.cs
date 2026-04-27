using System;
using System.Collections.Generic;
using System.Text;

class MyPriorityQueue<T>{
    private T[] items;
    private int[] priorities;
    private int count;
    public MyPriorityQueue(int capacity = 10) {
        items = new T[capacity];
        priorities = new int[capacity];
        count = 0;
    }
    private void Resize() {
        int newSize = items.Length * 2;
        T[] newItems = new T[newSize];
        int[] newPriorities = new int[newSize];
        for (int i = 0; i < count; i++) {
            newItems[i] = items[i];
            newPriorities[i] = priorities[i];
        }
        items = newItems;
        priorities = newPriorities;
    }
    public void Enqueue(T item, int priority) {
        if (count == items.Length) Resize();
        items[count] = item;
        priorities[count] = priority;
        count++;
    }
    public T Dequeue() {
        if (count == 0) throw new InvalidOperationException("Очередь пуста");
        int maxIndex = 0;
        for (int i = 1; i < count; i++) if (priorities[i] > priorities[maxIndex]) maxIndex = i;
        T result = items[maxIndex];
        for (int i = maxIndex; i < count - 1; i++) {
            items[i] = items[i + 1];
            priorities[i] = priorities[i + 1];
        }
        count--;
        return result;
    }
    public T Peek() {
        if (count == 0) throw new InvalidOperationException("Очередь пуста");
        int maxIndex = 0;
        for (int i = 1; i < count; i++) if (priorities[i] > priorities[maxIndex]) maxIndex = i;
        return items[maxIndex];
    }
    public int Find(T item) {
        for (int i = 0; i < count; i++) if (items[i].Equals(item)) return i;
        return -1;
    }
    public int Count() { return count; }
}