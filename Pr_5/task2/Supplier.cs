using System;
using System.Collections.Generic;
using System.Text;
class Supplier {
    public string Name { get; set; }
    public Supplier(string name) {
        Name = name;
    }
    public string Supply() {
        return $"Поставщик  {Name} доставляет продукты";
    }
}