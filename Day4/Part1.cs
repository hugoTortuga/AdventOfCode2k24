using System.Drawing;

internal class Part1
{
    public Part1()
    {
        string wordToFind = "XMAS";
        var letters = GetLetters(File.ReadAllLines("C:\\Users\\Hugo\\Downloads\\aventOfCode\\04-input.txt"));

        int result1 = 0;
        foreach (var letter in letters)
        {
            if (letter.Value != 'X')
                continue;
            SearchLetterAtXY('M', letter, SearchDirection.TopLeft);
            SearchLetterAtXY('M', letter, SearchDirection.Top);
            SearchLetterAtXY('M', letter, SearchDirection.TopRight);
            SearchLetterAtXY('M', letter, SearchDirection.Right);
            SearchLetterAtXY('M', letter, SearchDirection.BottomRight);
            SearchLetterAtXY('M', letter, SearchDirection.Bottom);
            SearchLetterAtXY('M', letter, SearchDirection.BottomLeft);
            SearchLetterAtXY('M', letter, SearchDirection.Left);

        }
        void SearchLetterAtXY(char charToSearch, Letter previousLetter, SearchDirection direction)
        {
            var currentIndexCharacterInXMAS = wordToFind.IndexOf(charToSearch);

            var nextPoint = GetNextPoint(direction);
            var currentLetter = letters.FirstOrDefault(l => l.X == (previousLetter.X + nextPoint.X) && l.Y == (previousLetter.Y + nextPoint.Y));
            if (currentLetter == null || currentLetter.Value != charToSearch)
                return;

            if (currentIndexCharacterInXMAS == wordToFind.Length - 1)
            {
                result1++;
                return;
            }
            var nextCharToSearch = wordToFind[++currentIndexCharacterInXMAS];
            SearchLetterAtXY(nextCharToSearch, currentLetter, direction);
        }

        Console.WriteLine($"Result is {result1}");
    }


    Point GetNextPoint(SearchDirection direction)
    {
        return direction switch
        {
            SearchDirection.TopLeft => new Point(-1, -1),
            SearchDirection.Top => new Point(0, -1),
            SearchDirection.TopRight => new Point(1, -1),
            SearchDirection.Right => new Point(1, 0),
            SearchDirection.BottomRight => new Point(1, 1),
            SearchDirection.Bottom => new Point(0, 1),
            SearchDirection.BottomLeft => new Point(-1, 1),
            SearchDirection.Left => new Point(-1, 0),
            _ => throw new NotImplementedException(),
        };
    }

    static List<Letter> GetLetters(string[] lines)
    {
        List<Letter> letters = [];
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (int j = 0; j < line.Length; j++)
            {
                letters.Add(new Letter(line[j], j, i));
            }
        }
        return letters;
    }

    internal class Letter(char value, int x, int y)
    {
        public char Value { get; set; } = value;
        public int X { get; set; } = x;
        public int Y { get; set; } = y;

    }

    internal enum SearchDirection
    {
        TopLeft,
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left
    }
}