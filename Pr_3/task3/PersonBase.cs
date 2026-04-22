using System;
using System.Collections.Generic;
using System.Text;
abstract class PersonBase
{
    public string FullName;
    public int Age;
    public string HealthStatus;

    public PersonBase(string name, int age, string status)
    {
        FullName = name;
        Age = age;
        HealthStatus = status;
    }
}