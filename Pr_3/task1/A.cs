using System;
using System.Collections.Generic;
using System.Text;
class A
{
    public int a;
    public int b;
    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public double CalcExpression()
    {
        return Math.Pow(b, 3) - 4 * Math.Sqrt(a);
    }
    public double SquareQuotient()
    {
        if (b == 0)
            throw new DivideByZeroException("b не может быть 0");

        return Math.Pow((double)a / b, 2);
    }
}

