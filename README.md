# Pacman Kata

Welcome to my pacman kata. The focus on this kata was to implement pacman using TDD, Top down approach and end to end tests.
## Task

Incomplete list of things the game needs:

- pacman is on a grid filled with dots
- pacman has a direction
- pacman moves on each tick
- user can rotate pacman
- pacman eats dots
- pacman wraps around
- pacman stops on wall
- pacman will not rotate into a wall
- game score (levels completed, number of dots eaten in this level)
- monsters…
- levels
- animate pacman eating (mouth opens and closes)

## Table of Contents

- How To Run
  - [Version](#version)
  - [Commands](#commands)
- Design Decisions
  - [Design Patterns](#design-patterns)

# How To Run

## Version

This kata is running dotnet 6 with xUnit as the testing framework.

## Commands

Build any .NET Core sample using the .NET Core CLI, which is installed with [the .NET Core SDK](https://www.microsoft.com/net/download). Then run
these commands from the CLI in the directory of any sample:

```console
cd Pacman.Code
dotnet build
dotnet run
```

### To Test


```console
cd Pacman.Tests
dotnet test
```

# Design Decisions

## Design Patterns
1. [Map](Docs/Maps.md)
2. [State pattern for pacman](Docs/StatePattern.md)
3. [Strategy pattern for ghosts](Docs/MultipleGhosts.md)


