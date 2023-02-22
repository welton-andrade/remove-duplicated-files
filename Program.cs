using System.Security.Cryptography;
using DuplicatedFiles;

Boolean delete = false;

if (args.Length < 1 || args.Length > 2)
{
    MessageHelp();
    return;
}

if(args.Length == 1)
{
    if(args[0] == null || !Directory.Exists(args[0]))
    {
        MessageInvalidDirectory();
        MessageHelp();
        return;
    }
} 
else 
{
    if(args[1] != "--l" && args[1] != "--list" && args[1] != "--d" && args[1] != "--delete")
    {
        MessageInvalidOption();
        MessageHelp();
        return;
    } else {
        if(args[1] == "--d" || args[1] == "--delete")
            delete = true;
    }
}

ICollection<string> files = Directory.GetFiles(args[0]);
List<string> listPath = new List<string>();
List<PathNChecksunMap> listPathNChecksun = new List<PathNChecksunMap>();

foreach (string filePath in files)
{
    var checksun = SHA256CheckSum(filePath);
    PathNChecksunMap pnc = new PathNChecksunMap(filePath, checksun);

    if(!listPathNChecksun.Contains(pnc))
        listPathNChecksun.Add(pnc);
    else
    {
        PathNChecksunMap found = listPathNChecksun.Where(x => x.Equals(pnc)).First();
        MessageFileFound(pnc.path, found.path);

        if(delete)
        {
            File.Delete(pnc.path);
            MessageFileDeleted(pnc.path);
        }
    }
}

string SHA256CheckSum(string filePath)
{
    using (SHA256 SHA256 = SHA256.Create())
    {
        using (FileStream fileStream = File.OpenRead(filePath))
            return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
    }
}

void MessageFileFound(String dupicatedPath, String originPath) 
{
    System.Console.ForegroundColor = ConsoleColor.Blue;
    System.Console.Write($"{dupicatedPath}");
    System.Console.ForegroundColor = ConsoleColor.White;
    System.Console.Write($" its a copy of ");
    System.Console.ForegroundColor = ConsoleColor.DarkGreen;
    System.Console.WriteLine($"{originPath}");
    System.Console.ForegroundColor = ConsoleColor.White;
}

void MessageFileDeleted(String fileDeleted) 
{
    System.Console.Write("Duplicated file ");
    System.Console.ForegroundColor = ConsoleColor.Blue;
    System.Console.Write($"{fileDeleted}");
    System.Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine($" deleted!");
    System.Console.ForegroundColor = ConsoleColor.White;
}

void MessageHelp() 
{
    System.Console.WriteLine("Usage: [directory] [option]\n\nOptions:\n\t--l|--list\t(default)\n\t--d|--delete");
}

void MessageInvalidDirectory()
{
    System.Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine("Invalid argument. Insert a valid Directory");
    System.Console.ForegroundColor = ConsoleColor.White;
}

void MessageInvalidOption()
{
    System.Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine("Invalid option. Insert a valid option");
    System.Console.ForegroundColor = ConsoleColor.White;
}
