using static System.Console;
class Program
{
    static void Main()
    {
        PasswordManager manager = new PasswordManager();
        try
        {
            string password = "abc123"; 
            manager.ValidatePassword(password);
            WriteLine("Пароль ок");
        }
        catch (WeakPasswordException ex)
        {
            WriteLine("Ошибка:");
            WriteLine(ex.Message);
        }
    }
}