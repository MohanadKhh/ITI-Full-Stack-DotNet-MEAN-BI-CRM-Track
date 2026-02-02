namespace Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = new Employee[3];

            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = new Employee();
                int id;
                string name;
                decimal salary;
                Gender gender;
                SecurityLevel securityLevel = 0;
                bool hasError;
                DateTime hireDate;

                Console.WriteLine($"Employee[{i + 1}] Id: ");
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("wrong id, id must be number");
                    Console.WriteLine($"Employee[{i + 1}] Id: ");
                }
                employees[i].Id = id;


                do
                {
                    Console.WriteLine($"Employee[{i + 1}] Name: ");
                    name = Console.ReadLine();
                }
                while (name.Length < 3 || name.Any(char.IsDigit));
                employees[i].Name = name;


                Console.WriteLine($"Employee[{i + 1}] Salary: ");
                while (!decimal.TryParse(Console.ReadLine(), out salary) || salary <= 0)
                {
                    Console.WriteLine("wrong salary, salary must be number");
                    Console.WriteLine($"Employee[{i + 1}] Salary: ");
                }
                employees[i].Salary = salary;


                Console.WriteLine($"Employee[{i + 1}] Gender: ");
                while (!Enum.TryParse(Console.ReadLine(), true, out gender) || !Enum.IsDefined(typeof(Gender), gender))
                {
                    Console.WriteLine("wrong gender data, must be male or female");
                    Console.WriteLine($"Employee[{i + 1}] Gender: ");
                }
                employees[i].Gender = gender;

                do
                {
                    hasError = false;
                    Console.WriteLine($"Employee[{i + 1}] Add Security Levels with comma separator: ");
                    Console.WriteLine("guest, Developer, secretary, DBA");
                    string input = Console.ReadLine();
                    string[] roles = input.Split(',');

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        hasError = true;
                    }
                    else
                    {
                        foreach (var role in roles)
                        {
                            if (Enum.TryParse(role.Trim(), true, out SecurityLevel parsedRole) && Enum.IsDefined(typeof(SecurityLevel), parsedRole))
                            {
                                securityLevel ^= parsedRole;
                            }
                            else
                            {
                                hasError = true;
                                break;
                            }
                        }
                    }
                }
                while (hasError);
                employees[i].SecurityLevel = securityLevel;

                Console.WriteLine($"Employee[{i + 1}] HireDate (d/m/yyyy): ");
                while (!DateTime.TryParseExact(Console.ReadLine(), "d/M/yyyy", null, System.Globalization.DateTimeStyles.None, out hireDate))
                {
                    Console.WriteLine("Invalid date, use dd/mm/yyyy");
                }

                employees[i].HireData = new HireData(
                    hireDate.Day,
                    hireDate.Month,
                    hireDate.Year
                );
            }

            foreach (Employee e in employees)
            {
                Console.WriteLine(e.print());
            }
        }
    }
}