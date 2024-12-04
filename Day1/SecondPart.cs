public class SecondPart
{
    public SecondPart()
    {
        int similarityScore = 0;
        var content = File.ReadAllText("C:\\Users\\Hugo\\Downloads\\aventOfCode\\01-input.txt");

        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var row in content.Split('\n'))
        {
            var rowSplitted = row.Split("   ");
            leftList.Add(int.Parse(rowSplitted[0]));
            rightList.Add(int.Parse(rowSplitted[1]));
        }

        for (int i = 0; i < leftList.Count; i++)
            similarityScore += rightList.Where(value => value == leftList[i]).Count() * leftList[i];
        
        Console.WriteLine("The result should be : " + similarityScore);
    }
}