using Pacman.Code;

namespace Pacman.Tests;

public class GetGameStateTest
{
    [Fact]
    public void GetMapFromFile_Returns_JaggedArray_Of_ReadFile()
    {
        var expectedMapJaggedArray = new string[][]
        {
            new string[] {"╔","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","╦","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","╗"},
            new string[] {"║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"},
            new string[] {"║"," ","∘"," ","╔","═","╗"," ","∘"," ","╔","═","═","═","═","═","╗"," ","∘"," ","║"," ","∘"," ","╔","═","═","═","═","═","╗"," ","∘"," ","╔","═","╗"," ","∘"," ","║"},
            new string[] {"║"," ","+"," ","╚","═","╝"," ","∘"," ","╚","═","═","═","═","═","╝"," ","∘"," ","╨"," ","∘"," ","╚","═","═","═","═","═","╝"," ","∘"," ","╚","═","╝"," ","+"," ","║"},
            new string[] {"║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"},
            new string[] {"║"," ","∘"," ","═","═","═"," ","∘"," ","╥"," ","∘"," ","═","═","═","═","═","═","╦","═","═","═","═","═","═"," ","∘"," ","╥"," ","∘"," ","═","═","═"," ","∘"," ","║"},
            new string[] {"║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"},
            new string[] {"╚","═","═","═","═","═","╗"," ","∘"," ","╠","═","═","═","═","═","═"," "," "," ","╨"," "," "," ","═","═","═","═","═","═","╣"," ","∘"," ","╔","═","═","═","═","═","╝"},
            new string[] {" "," "," "," "," "," ","║"," ","∘"," ","║"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","║"," ","∘"," ","║"," "," "," "," "," "," "},
            new string[] {"═","═","═","═","═","═","╝"," ","∘"," ","╨"," "," "," ","╔","═","═","═","═","-","-","-","═","═","═","═","╗"," "," "," ","╨"," ","∘"," ","╚","═","═","═","═","═","═"},
            new string[] {" "," "," ","<"," "," "," "," ","∘"," "," "," "," "," ","║"," "," "," "," "," "," "," "," "," "," "," ","║"," "," "," "," "," ","∘"," "," "," "," "," "," "," "," "},
            new string[] {"═","═","═","═","═","═","╗"," ","∘"," ","╥"," "," "," ","║"," "," "," "," "," "," "," "," "," "," "," ","║"," "," "," ","╥"," ","∘"," ","╔","═","═","═","═","═","═"},
            new string[] {" "," "," "," "," "," ","║"," ","∘"," ","║"," "," "," ","╚","═","═","═","═","═","═","═","═","═","═","═","╝"," "," "," ","║"," ","∘"," ","║"," "," "," "," "," "," "},
            new string[] {" "," "," "," "," "," ","║"," ","∘"," ","║"," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ","║"," ","∘"," ","║"," "," "," "," "," "," "},
            new string[] {"╔","═","═","═","═","═","╝"," ","∘"," ","╨"," "," "," ","═","═","═","═","═","═","╦","═","═","═","═","═","═"," "," "," ","╨"," ","∘"," ","╚","═","═","═","═","═","╗"},
            new string[] {"║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"},
            new string[] {"║"," ","∘"," ","═","═","╗"," ","∘"," ","═","═","═","═","═","═","═"," ","∘"," ","╨"," ","∘"," ","═","═","═","═","═","═","═"," ","∘"," ","╔","═","═"," ","∘"," ","║"},
            new string[] {"║"," ","+"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","+"," ","║"},
            new string[] {"╠","═","═"," ","∘"," ","╨"," ","∘"," ","╥"," ","∘"," ","═","═","═","═","═","═","╦","═","═","═","═","═","═"," ","∘"," ","╥"," ","∘"," ","╨"," ","∘"," ","═","═","╣"},
            new string[] {"║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"},
            new string[] {"║"," ","∘"," ","═","═","═","═","═","═","╩","═","═","═","═","═","═"," ","∘"," ","╨"," ","∘"," ","═","═","═","═","═","═","╩","═","═","═","═","═","═"," ","∘"," ","║"},
            new string[] {"║"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","∘"," ","║"},
            new string[] {"╚","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","═","╝"}

        };
        var expectedHeight = 23;
        var expectedWidth = 41;
        var expectedPacmanLocation = new Coordinate(3, 10);
        var expectedGameState =
            new GameState(expectedHeight, expectedWidth, expectedMapJaggedArray, expectedPacmanLocation);
        
        var actualGameState = new GameDownload().DownloadGameStateFromFile("../../../TestMap.txt");
        Assert.Equal(expectedHeight, actualGameState.Height);
        Assert.Equal(expectedWidth, actualGameState.Width);
        Assert.Equal(expectedPacmanLocation, actualGameState.PacmanLocation);
        Assert.Equal(expectedMapJaggedArray, actualGameState.Map);
        //Assert.Equal(expectedGameState, actualGameState);
    }
    
    [Fact]
    public void GetMapFromFile_Throws_In()
    {
        var actualGameState = new GameDownload();

        var ActualEmptyFileException = Assert.Throws<InvalidDataException>(() => actualGameState.DownloadGameStateFromFile("../../../EmptyTextFile.txt"));
        Assert.Equal("File is Empty.", ActualEmptyFileException.Message);
        
    }
}

