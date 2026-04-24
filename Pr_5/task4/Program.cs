using static System.Console;
class Program
{
    static void Main() {
        FileManager manager = new FileManager();
        IReadFile reader = manager;
        IWriteFile writer = manager;
        WriteLine(reader.AccessFile("1.txt"));
        WriteLine(writer.AccessFile("4.txt"));
    }
}