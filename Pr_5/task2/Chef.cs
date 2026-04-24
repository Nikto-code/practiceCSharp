class Chef{
    public string Name { get; set; }
    public Chef(string name) {
        Name = name;
    }
    public string Cook(string dish) {
        return $"{Name} готовит {dish}";
    }
}