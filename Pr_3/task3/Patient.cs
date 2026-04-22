using System;
using System.Collections.Generic;
using System.Text;
sealed class Patient : PersonBase
{
    public int Severity;
    public Patient(string name, int age, string status, int severity)
        : base(name, age, status)
    {
        Severity = severity;
    }
}
sealed class Doctor : PersonBase
{
    public string Specialty;
    public Doctor(string name, int age, string status, string specialty)
        : base(name, age, status)
    {
        Specialty = specialty;
    }
}