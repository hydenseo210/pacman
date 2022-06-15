namespace Pacman.Code;

public class Move
{
    public string Component { get; set; }
    public int Amount { get; set; }

    public Move(string component, int amount)
    {
        Component = component;
        Amount = amount;
    }
}