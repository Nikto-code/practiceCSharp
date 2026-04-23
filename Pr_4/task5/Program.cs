using static System.Console;
class Program
{
    static void Main()
    {
        MusicalInstrument g = new Guitar();
        MusicalInstrument p = new Piano();

        WriteLine(g.PlaySound());
        WriteLine(g.Tune());

        WriteLine(p.PlaySound());
        WriteLine(p.Tune());
    }
}