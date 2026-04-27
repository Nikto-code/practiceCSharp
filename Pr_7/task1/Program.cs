using static System.Console;
using System;
class Program {
    static void Main() {
        Warehouse warehouse = new Warehouse();
        try {
            warehouse.CheckStock(0);
        }
        catch (OutOfStockException ex) {
            WriteLine("Ошибка: " + ex.Message);
        }
    }
}