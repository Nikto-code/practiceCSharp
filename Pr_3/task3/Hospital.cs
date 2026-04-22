using System;
using System.Collections.Generic;
using System.Text;

class Hospital
{
    public PersonBase[] People;

    public Hospital(PersonBase[] people)
    {
        People = people;
    }
    public Patient GetMostCriticalPatient()
    {
        Patient result = null;
        int maxSeverity = -1;

        for (int i = 0; i < People.Length; i++)
        {
            if (People[i] is Patient)
            {
                Patient p = (Patient)People[i];

                if (p.Severity > maxSeverity)
                {
                    maxSeverity = p.Severity;
                    result = p;
                }
            }
        }

        return result;
    }
    public Doctor[] GetDoctorsBySpecialty(string specialty)
    {
        int count = 0;
        for (int i = 0; i < People.Length; i++)
        {
            if (People[i] is Doctor)
            {
                Doctor d = (Doctor)People[i];
                if (d.Specialty == specialty)
                    count++;
            }
        }
        Doctor[] result = new Doctor[count];
        int index = 0;
        for (int i = 0; i < People.Length; i++)
        {
            if (People[i] is Doctor)
            {
                Doctor d = (Doctor)People[i];
                if (d.Specialty == specialty)
                {
                    result[index] = d;
                    index++;
                }
            }
        }
        return result;
    }
}