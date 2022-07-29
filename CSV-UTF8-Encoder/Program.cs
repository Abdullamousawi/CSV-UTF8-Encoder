using System.Text;

string inputPath = @"C:\Users\username\Desktop\data.csv";
string outputPath = @"C:\Users\username\Desktop\new_data.csv";

List<string> lines = new List<string>();

Start();

void Start()
{
    Customized.Print($".csv input path: '{inputPath}'\n.csv output path: '{outputPath}'\nDo you confirm?", ConsoleColor.Yellow);

    var input = Console.ReadLine();
    switch(input.ToLower())
    {
        case "y": Read(inputPath); break;
        case "n": ChangePaths(); break;
        default:
            Customized.Print("Invalid option.  Please type either 'Y' (for yes) or 'N' (for no).  Do not type the single quotation mark", ConsoleColor.Red);
            Start();
            break;
    }
}


void Read(string path)
{
    int i = 0;

    Customized.Print("Begins Reading...", ConsoleColor.Cyan);
    try
    {
        foreach (var line in File.ReadLines(path, Encoding.UTF8))
        {
            lines.Add(line);
            Customized.Print($"{i} >> {line}");
            i++;
        }
    } catch (Exception e) { Customized.Print(e, ConsoleColor.Red); }

    Customized.Print("✓ Finished Reading", ConsoleColor.Green);
    Customized.Print("Begins Writing...", ConsoleColor.Cyan);

    Write(outputPath);
    Customized.Print("✓ Finished Writing", ConsoleColor.Green);
}

void Write(string path)
{
    try { File.WriteAllLines(path, lines, Encoding.UTF8); }
    catch (Exception e) { Customized.Print(e, ConsoleColor.Red); }
}

void ChangePaths()
{
    try
    {
        Customized.Print("Type or paste the (input) path: ", ConsoleColor.Yellow);
        inputPath = Console.ReadLine();

        Customized.Print("Type or paste the (output) path: ", ConsoleColor.Yellow);
        outputPath = Console.ReadLine();
    } catch (Exception e) { Customized.Print(e, ConsoleColor.Red); }

    Customized.Print("✓ Paths Were Changed", ConsoleColor.Green);
    Start();
}

public static class Customized
{
    public static void Print(object obj) => Print(obj, ConsoleColor.White);

    public static void Print(object obj, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(obj);
        Console.ResetColor();
    }
}