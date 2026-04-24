using static System.Console;
class Program {
    static void Main() {
        Chef c1 = new Chef("Гриша");
        Chef c2 = new Chef("Боб");
        Supplier s1 = new Supplier("Беледа");
        Supplier s2 = new Supplier("Волковыский Мясокомбинат");
        Restaurant[] restaurants = new Restaurant[] {
            new Restaurant("R1", new Chef[]{c1, c2}, s1, new string[]{"Суп","Стейк"}),
            new Restaurant("R2", new Chef[]{c2}, s2, new string[]{"Пицца","Пельмени"})
        };
        for (int i = 0; i < restaurants.Length; i++) {
            WriteLine(restaurants[i].Name);
            string[] res = restaurants[i].PrepareDishes();
            for (int j = 0; j < res.Length; j++) WriteLine(res[j]);
        }
    }
}