using static System.Console;
class Program
{
    static void Main()
    {
        double xA = 0, yA = 0;
        double xB = 3, yB = 0;
        double xC = 0, yC = 4;
        double xD = 1, yD = 1;

        WriteLine(Geometry.Perim(xA, yA, xB, yB, xC, yC)); 
        WriteLine(Geometry.Perim(xA, yA, xB, yB, xD, yD)); 
        WriteLine(Geometry.Perim(xA, yA, xC, yC, xD, yD)); 
    }
}