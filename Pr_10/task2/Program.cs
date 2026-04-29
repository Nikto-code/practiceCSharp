using static System.Console;

class Program
{
    static void Main()
    {
        var service = new EncryptionService(new AESEncryption());

        WriteLine(service.Process("hello"));

        service.SetStrategy(new DESEncryption());
        WriteLine(service.Process("hello"));

        service.SetStrategy(new NoEncryption());
        WriteLine(service.Process("hello"));
    }
}