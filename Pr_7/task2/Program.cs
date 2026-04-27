using static System.Console;
using System.Collections.Generic;

class Program {
    static void Main() {
        CollectionHandler handler = new CollectionHandler();
        List<int> list = new List<int> { 1, 2, 3 };
        try {
            int value = handler.SafeGetElement(list, 10);
            WriteLine(value);
        }
        catch (CollectionException ex) {
            WriteLine(ex.Message);
            if (ex.InnerException != null) WriteLine("Причина: " + ex.InnerException.Message);
        }
    }
}