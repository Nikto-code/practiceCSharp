class InventorySystem
{
    public void UpdateInventory(object sender, string item)
    {
        LastMessage = $"Inventory: обновлен {item}";
    }
    public string LastMessage { get; private set; }
}