using static System.Console;

class Program
{
    static void Main()
    {
        Person[] people = {
            new Person("Иван", "Москва"),
            new Person("Анна", "Минск"),
            new Person("Петр", "Москва"),
            new Person("Олег", "Киев"),
            new Person("Мария", "Москва")
        };
        WriteLine("Самый популярный город: " +
            ArrayUtils.FindMostPopularCity(people));
    }
}