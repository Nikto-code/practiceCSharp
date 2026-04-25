class InventoryTracker
{
    private InventorySystem inventory = new InventorySystem();
    private SecuritySystem security = new SecuritySystem();

    public string[] Track(WarehouseMonitor monitor, string item)
    {
        monitor.ItemMoved += inventory.UpdateInventory;
        monitor.ItemMoved += security.CheckAccess;

        monitor.MoveItem(item);

        return new string[]
        {
            inventory.LastMessage,
            security.LastMessage
        };
    }
}