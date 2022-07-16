namespace Pacman.Tests;

public static class Compare
{
    public static bool Dictionaries(Dictionary<Coordinate, Cell> x, Dictionary<Coordinate, Cell> y)
    {
        if (x.Count != y.Count)
            return false;
        if (x.Keys.Except(y.Keys).Any())
            return false;
        return !y.Keys.Except(x.Keys).Any() && x.All(pair => x[pair.Key].GetType() == y[pair.Key].GetType());
    }
}