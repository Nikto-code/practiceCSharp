using System.Collections.Generic;

class ListProcessor{
    public int GetElementAt(List<int> list, int index) {
        if (index < 0 || index >= list.Count) throw new IndexOutOfRangeException("Индекс вне диапазона списка");
        return list[index];
    }
}