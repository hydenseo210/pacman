namespace Pacman.Code;

public interface IConsoleWrapper
{
    ConsoleKeyInfo ReadKey();
    void Write(string data);
    public string? Read();
}