namespace Day1;
public class FirstPart
{
    public FirstPart()
    {

        int howFarAreLists = 0;
        var content = File.ReadAllText("C:\\Users\\Hugo\\Downloads\\aventOfCode\\01-input.txt");

        var leftList = new List<int>();
        var rightList = new List<int>();

        foreach (var row in content.Split('\n'))
        {
            var rowSplitted = row.Split("   ");
            leftList.Add(int.Parse(rowSplitted[0]));
            rightList.Add(int.Parse(rowSplitted[1]));
        }

        leftList.Sort();
        rightList.Sort();

        for (int i = 0; i < leftList.Count; i++)
            howFarAreLists += Math.Abs(leftList[i] - rightList[i]);
        

        Console.WriteLine("The result should be : " + howFarAreLists);

    }
}
