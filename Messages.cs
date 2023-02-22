// namespace DuplicatedFiles.Messages;

public static class Messages 
{
  public static void MessageFileFound(String dupicatedPath, String originPath) 
  {
      System.Console.ForegroundColor = ConsoleColor.Blue;
      System.Console.Write($"{dupicatedPath}");
      System.Console.ForegroundColor = ConsoleColor.White;
      System.Console.Write($" its a copy of ");
      System.Console.ForegroundColor = ConsoleColor.DarkGreen;
      System.Console.WriteLine($"{originPath}");
      System.Console.ForegroundColor = ConsoleColor.White;
  }

  public static void MessageFileDeleted(String fileDeleted) 
  {
      System.Console.Write("Duplicated file ");
      System.Console.ForegroundColor = ConsoleColor.Blue;
      System.Console.Write($"{fileDeleted}");
      System.Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine($" deleted!");
      System.Console.ForegroundColor = ConsoleColor.White;
  }

  public static void MessageHelp() 
  {
      System.Console.WriteLine("Usage: [directory] [option]\n\nOptions:\n\t--l|--list\t(default)\n\t--d|--delete");
  }

  public static void MessageInvalidDirectory()
  {
      System.Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine("Invalid argument. Insert a valid Directory");
      System.Console.ForegroundColor = ConsoleColor.White;
  }

  public static void MessageInvalidOption()
  {
      System.Console.ForegroundColor = ConsoleColor.Red;
      System.Console.WriteLine("Invalid option. Insert a valid option");
      System.Console.ForegroundColor = ConsoleColor.White;
  }

}
