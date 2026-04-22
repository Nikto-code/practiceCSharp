using static System.Console;

class Program
{
    static void Main()
    {
        PersonBase[] people =
        {
            new Patient("Иван Иванов", 40, "Тяжелое", 9),
            new Patient("Петр Петров", 30, "Среднее", 5),
            new Doctor("Сидоров", 50, "Здоров", "Хирург"),
            new Doctor("Козлов", 45, "Здоров", "Терапевт"),
            new Doctor("Смирнов", 60, "Здоров", "Хирург")
        };
        Hospital hospital = new Hospital(people);
        var critical = hospital.GetMostCriticalPatient();
        WriteLine("Самый тяжелый пациент: " + critical.FullName);
        var doctors = hospital.GetDoctorsBySpecialty("Хирург");
        WriteLine("\nХирурги:");
        for (int i = 0; i < doctors.Length; i++)
        {
            WriteLine(doctors[i].FullName);
        }
    }
}