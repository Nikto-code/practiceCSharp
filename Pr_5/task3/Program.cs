using static System.Console;
class Program
{
    static void Main()
    {
        SmartDevice[] devices = new SmartDevice[]
        {
            new SmartSpeaker("Яндекс Станция"),
            new Smartphone("iPhone"),
            new SmartSpeaker("Google Nest"),
            new Smartphone("Samsung")
        };

        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i] is ICanMakeCalls caller)
            {
                WriteLine(caller.MakeCall("123-456"));
            }
        }
    }
}