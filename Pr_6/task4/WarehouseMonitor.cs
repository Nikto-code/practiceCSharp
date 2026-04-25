using System;
using System.Collections.Generic;
using System.Text;

class WarehouseMonitor
{
    public event EventHandler<string>? ItemMoved;

    public void MoveItem(string itemName)
    {
        ItemMoved?.Invoke(this, itemName);
    }
}