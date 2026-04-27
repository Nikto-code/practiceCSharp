using System;
using System.Collections.Generic;
using System.Text;

class Warehouse{
    public void CheckStock(int quantity) {
        if (quantity < 1)  throw new OutOfStockException("Количество товара меньше 1");
    }
}