namespace Pacman.Code;

public class ConsoleWrapper : IConsoleWrapper
{
    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey(true);
    }

    public void Write(string data)
    {
        Console.Write(data);
    }

    public string? Read()
    {
        return Console.ReadLine();
    }
    public bool KeyAvailable => Console.KeyAvailable;
}