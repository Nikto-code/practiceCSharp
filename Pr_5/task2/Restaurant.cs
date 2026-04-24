class Restaurant {
    public string Name { get; set; }
    public Chef[] Chefs { get; set; }
    private Menu menu;
    public Supplier Supplier { get; set; }
    public Restaurant(string name, Chef[] chefs, Supplier supplier, string[] dishes){
        Name = name;
        Chefs = chefs;
        Supplier = supplier;
        menu = new Menu(dishes);
    }
    public string[] PrepareDishes() {
        string[] result = new string[menu.Dishes.Length + 1];
        int index = 0;
        result[index++] = Supplier.Supply();
        for (int i = 0; i < menu.Dishes.Length; i++){
            Chef chef = Chefs[i % Chefs.Length];
            result[index++] = chef.Cook(menu.Dishes[i]);
        }
        return result;
    }
}
