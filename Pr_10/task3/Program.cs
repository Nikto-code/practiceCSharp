using static System.Console;

class Program
{
    static void Main()
    {
        var channel = new YouTubeChannel("A4");
        var user1 = new User("ВЛАДыка-тьмы148");
        var user2 = new User("СаняНина");
        channel.Subscribe(user1);
        channel.Subscribe(user2);
        channel.UploadVideo("ГЛЕНТ Стал БАБУШКОЙ на 24 Часа ! *Пранк*");
        foreach (var msg in user1.Notifications)
            WriteLine(msg);
        foreach (var msg in user2.Notifications)
            WriteLine(msg);
    }
}