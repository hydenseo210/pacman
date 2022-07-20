
Pacman inherits the state class
```csharp
public abstract class State: IPrintable
    {
        public abstract Directions Direction { get;}
        public abstract bool Eating { get; set; }
        public abstract Coordinate MoveForward(Coordinate location);
        public abstract string Print();
    }
```
Pacman starts of with the facing right state and not eating state
```csharp
public class ThePacman : Cell, IMovable
    {
        public State State = new FacingRight();

        public ThePacman(Directions currentDirection = Directions.Right)
        {
            ChangeDirection(currentDirection);
        }

        public Coordinate MoveForward(Coordinate location) =>
            State.MoveForward(location);

        public void ChangeDirection(Directions direction)
        {
            State = direction switch
            {
                Directions.Left => new FacingLeft(),
                Directions.Right => new FacingRight(),
                Directions.Up => new FacingUp(),
                Directions.Down => new FacingDown(),
                _ => State
            };
        }

        public override bool IsValidPath() => true;

        public override string Print() => State.Print().Pastel(Color.FromArgb(255, 255, 0));
    }
```
Depending on the keys pressed by the user pacman's state can change resulting
in overriding the state methods to return a different orientation for
pacman.

By changing the eat boolean within the state pacman can show 
eating animation when eating the food cell while the game is running 
```csharp
public class FacingLeft : State
    {
        public override Directions Direction { get; } = Directions.Left;
        public override bool Eating { get; set; } = false;

        public override Coordinate MoveForward(Coordinate location) =>
            new(location.X, location.Y - 1);

        public override string Print() => !Eating? ">" : "-";
    }
```