using System.Drawing;

internal class Part2
{
    public Part2()
    {
        var letters = GetLetters(File.ReadAllLines("C:\\Users\\Hugo\\Downloads\\aventOfCode\\04-input.txt"));

        int result2 = 0;
        foreach (var letter in letters)
        {
            if (letter.Value != 'A')
                continue;

            var letterTopLeft = GetLetter(letter, SearchDirection.TopLeft);
            var letterTopRight = GetLetter(letter, SearchDirection.TopRight);
            var letterBottomRight = GetLetter(letter, SearchDirection.BottomRight);
            var letterBottomLeft = GetLetter(letter, SearchDirection.BottomLeft);

            var cornersLetters = new List<Letter> { letterTopLeft, letterTopRight, letterBottomRight, letterBottomLeft };

            if (cornersLetters.Where(l => l != null).Count() < 4 || cornersLetters.Any(l => l.Value != 'S' && l.Value != 'M'))
                continue;

            if (cornersLetters.Where(l => l.Value == 'S').Count() != 2 || cornersLetters.Where(l => l.Value == 'M').Count() != 2)
                continue;

            if (!CheckCorner('M', letterTopLeft, letterTopRight, letterBottomRight, letterBottomLeft))
                continue;
            if (!CheckCorner('S', letterTopLeft, letterTopRight, letterBottomRight, letterBottomLeft))
                continue;
            result2++;     
        }

        bool SearchLetterAtXY(char charToSearch, Letter previousLetter, SearchDirection direction)
        {
            var nextPoint = GetNextPoint(direction);
            var currentLetter = letters.FirstOrDefault(l => l.X == (previousLetter.X + nextPoint.X) && l.Y == (previousLetter.Y + nextPoint.Y));
            
            return (currentLetter != null && currentLetter.Value == charToSearch);
        }


        Letter GetLetter(Letter previousLetter, SearchDirection direction)
        {
            var nextPoint = GetNextPoint(direction);
            var currentLetter = letters.FirstOrDefault(l => l.X == (previousLetter.X + nextPoint.X) && l.Y == (previousLetter.Y + nextPoint.Y));

            return currentLetter;
        }


        Console.WriteLine($"Result is {result2}");
    }

    bool CheckCorner(char c, Letter letterTopLeft, Letter letterTopRight, Letter letterBottomRight, Letter letterBottomLeft)
    {
        if (letterTopLeft.Value == c && letterTopRight.Value != c && letterBottomLeft.Value != c)
            return false;
        if (letterTopRight.Value == c && letterTopLeft.Value != c && letterBottomRight.Value != c)
            return false;
        if (letterBottomRight.Value == c && letterTopRight.Value != c && letterBottomLeft.Value != c)
            return false;
        if (letterBottomLeft.Value == c && letterTopLeft.Value != c && letterBottomRight.Value != c)
            return false;

        return true;
    }

    Point GetNextPoint(SearchDirection direction)
    {
        return direction switch
        {
            SearchDirection.TopLeft => new Point(-1, -1),
            SearchDirection.TopRight => new Point(1, -1),
            SearchDirection.BottomRight => new Point(1, 1),
            SearchDirection.BottomLeft => new Point(-1, 1),
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
        TopRight,
        BottomRight,
        BottomLeft
    }
}