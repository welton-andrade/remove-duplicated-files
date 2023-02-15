using System.Security.Cryptography;

if(args.Length < 1)
    return;

ICollection<string> files = Directory.GetFiles(args[0]);
List<string> listPath = new List<string>();


foreach (string filePath in files)
{
    var checksun = SHA256CheckSum(filePath);
    if(!listPath.Contains(checksun))
        listPath.Add(checksun);
    else {
        File.Delete(filePath);
        // File.Move(filePath, @"C:\Temp\" + Path.GetFileName(filePath));
        string? found = listPath.Find(x => x == checksun);
        System.Console.WriteLine("Found file {0} - {1}", filePath, found);
        System.Console.WriteLine("Remove file {0} - {1}", filePath, checksun);
    }
    // System.Console.WriteLine(temp._CheckSun);
}


string SHA256CheckSum(string filePath)
{
    using (SHA256 SHA256 = SHA256.Create())
    {
        using (FileStream fileStream = File.OpenRead(filePath))
            return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
    }
}
