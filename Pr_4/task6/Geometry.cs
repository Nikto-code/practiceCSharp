using System;
using System.Collections.Generic;
using System.Text;

class Geometry
{
    public static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public static double Perim(
        double xA, double yA,
        double xB, double yB,
        double xC, double yC)
    {
        double AB = Distance(xA, yA, xB, yB);
        double BC = Distance(xB, yB, xC, yC);
        double AC = Distance(xA, yA, xC, yC);

        return AB + BC + AC;
    }
}
