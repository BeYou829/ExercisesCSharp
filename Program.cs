using System.Diagnostics;

Console.WriteLine(@"Ejercicios de práctica

1. Es par o Impar?
2. Tabla de multiplicar
3. Cálculo de promedios y clasificación
4. Contar palabras y caracteres
5. Números perfectos
");
Console.Write("Selecciona una opción: ");

string option = Console.ReadLine() ?? "";

switch (option.ToUpper())
{
    case "1":
        IsEven();
        break;
    case "2":
        GenerateMultiplyTable();
        break;
    case "3":
        GetQualifications();
        break;
    case "4":
        WordCount();
        break;
    case "5":
        GetPerfectNumbers();
        break;
    default:
        Console.WriteLine("Opción no válida");
        break;
}










#region IsEven
static void IsEven()
{
    Console.WriteLine(@$"Determina el número par o impar");
    Console.Write("Introduce un número: ");

    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            string resultado = (numero % 2 == 0) ? "Par" : "Impar";
            Console.WriteLine($"El número {numero} es {resultado}.");
            break;
        }
        else
        {
            Console.Write("Entrada inválida. Por favor, introduce un número válido.");
        }
    }
}
#endregion
#region Calc
static void GenerateMultiplyTable()
{
    Console.Clear();
    const int maxMultiply = 10;
    Console.WriteLine("=== Multiplicadora Personalizada ===");
    Console.WriteLine($"Introduce un número y te mostraré su tabla de multiplicar (hasta el {maxMultiply}):");
    Console.Write("Número: ");
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine($"\nTabla del {numero}:");

            for (int i = 1; i <= maxMultiply; i++)
            {
                Console.WriteLine($"{numero,3} * {i,3} = {numero * i,3}");
            }
            break;
        }
        else
        {
            Console.WriteLine("Entrada inválida, introduzca un número.");
        }
    }
}
#endregion
#region Qualifications
static void GetQualifications()
{
    Console.Clear();
    Console.WriteLine("Cálculo de promedios y clasificación");
    List<int> notes = new();
    int aprobadas = 0;
    int reprobadas = 0;
    while (true)
    {
        Console.Write("Ingresa una calificación (o escribe 'fin' para terminar): ");
        string valor = Console.ReadLine() ?? "";
        if (valor.ToUpper().Trim() == "FIN")
            break;

        if (int.TryParse(valor, out int numero))
        {
            if (numero >= 0 && numero <= 100)
            {
                _ = numero >= 70 ? aprobadas++ : reprobadas++;
                notes.Add(numero);
            }
            else
            {
                Console.WriteLine($"El {numero} no es válido");
            }
        }
    }
    if (notes.Count > 0)
    {
        Console.WriteLine(@$"Tú promedio de calificaciones es: {$"{notes.Average():F2}"}
    Aprobaste: {aprobadas}
    Reprobaste: {reprobadas}");
    }
    else
    {
        Console.WriteLine("No se introdujeron notas");
    }
}
#endregion
#region WordCount
static void WordCount()
{
    Console.Clear();
    Console.WriteLine("Contar Palabras y Caracteres");

    string phrase = Console.ReadLine()??"";

    List<string> words = phrase.Trim()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToList();

    int wordCount = words.Count;

    int charCount = phrase.Replace(" ", "").Length;

    Console.Write("Introduce la palabra a buscar: ");
    string findWordRepeated = Console.ReadLine() ?? "";

    int wordRepeatedCount = words.Count(x => x.Equals(findWordRepeated, StringComparison.CurrentCultureIgnoreCase));

    Console.WriteLine($"Cantidad de palabras: {wordCount}");
    Console.WriteLine($"Cantidad de caracteres: {charCount}");
    Console.WriteLine($"La palabra {findWordRepeated} {((wordRepeatedCount >= 1) ? $"aparece {wordRepeatedCount} veces" : "no aparece en la frase.")}");
}
#endregion
#region PerfectNumbers
static void GetPerfectNumbers()
{
    Console.Clear();
    Console.WriteLine("Introduce un número para determinar si es perfecto: ");
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int inputNumber) && inputNumber > 0)
        {
            int divisorsSum = 0;
            for (int i = 1; i < inputNumber; i++)
            {
                if (inputNumber % i == 0)
                    divisorsSum += i;
            }

            int diff = Math.Abs(inputNumber - divisorsSum);
            if (divisorsSum == inputNumber)
            {
                Console.WriteLine($"{inputNumber} es un número perfecto.");
                break;
            }
            else if(divisorsSum < inputNumber)
            {
                Console.WriteLine($"{inputNumber} no es un número perfecto porque le hace falta {diff}.");
            }
            else
            {
                Console.WriteLine($"{inputNumber} no es un número perfecto porque le sobran {diff}.");
            }
            break;
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, introduce un número válido.");
        }
    }
}
#endregion