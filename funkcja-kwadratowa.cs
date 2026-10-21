Console.WriteLine("Rozwiązywanie równania kwadratowego ax^2 + bx + c = 0");

do 
{

    Console.WriteLine("Podaj a:");
    double a;
    while (!double.TryParse(Console.ReadLine(), out a))
    {
        Console.WriteLine("Nieprawidłowa wartość a. Wprowadź liczbę.");
    }
    Console.WriteLine("Podaj b:");
    double b;
    while (!double.TryParse(Console.ReadLine(), out b))
    {
        Console.WriteLine("Nieprawidłowa wartość b. Wprowadź liczbę.");
    }
    Console.WriteLine("Podaj c:");
    double c;
    while (!double.TryParse(Console.ReadLine(), out c))
    {
        Console.WriteLine("Nieprawidłowa wartość c. Wprowadź liczbę.");
    }
    double x;
    if (a == 0)
    {
        if (b == 0)
        {
            if (c == 0)
            {
                Console.WriteLine("Równanie ma nieskończenie wiele rozwiązań.");
            }
            else
            {
                Console.WriteLine("Równanie nie ma rozwiązań.");
            }
        }
        else
        {
            Console.WriteLine("Równanie jest liniowe");
            Console.WriteLine($"Równanie ma jedno rozwiązanie: \nx = {x = -c / b}");
        }
    }
    else
    {
        Console.WriteLine("Równanie jest równaniem kwadratowym.");
        double delta = b * b - 4 * a * c;
        Console.WriteLine($"Delta = {delta}");
        if (delta < 0)
        {
            Console.WriteLine("Równanie nie ma rozwiązań rzeczywistych.");
        }
        else if (delta == 0)
        {
            Console.WriteLine($"Równanie ma jedno rozwiązanie: \nx = {x = -b / (2 * a)}");
        }
        else
        {
            Console.WriteLine($"Równanie ma dwa rozwiązania: \nx1 = {(-b - Math.Sqrt(delta)) / (2 * a)}, \nx2 = {(-b + Math.Sqrt(delta)) / (2 * a)}");
        }
    }
    Console.WriteLine("\nCzy chcesz rozwiązać kolejne równanie? (T/N)");
} while (Console.ReadLine().ToUpper() == "T");
