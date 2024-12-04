Console.WriteLine("Start");

int nbSafeReport = 0;
foreach (var report in File.ReadAllLines("C:\\Users\\Hugo\\Downloads\\aventOfCode\\02-input.txt"))
{
    var levels = report.Split(' ').Select(lvl => int.Parse(lvl)).ToList();
    bool reportAscending = levels[0] > levels[^1];
    bool isSafe = true;
    bool tolerance = true;
    for (int i = 1; i < levels.Count - 1; i++)
    {
        var diff = Math.Abs(levels[i] - levels[i + 1]);
        var levelCurrentAscending = levels[i - 1] > levels[i];
        if (diff > 3 || diff < 1 || reportAscending != levelCurrentAscending)
        {
            if (tolerance)
            {
                tolerance = false;
            }
            else
            {
                isSafe = false;
                break;
            }
        }
    }

    if (isSafe)
        nbSafeReport++;
}

/*
int nbSafeReport = 0;
foreach (var report in File.ReadAllLines("C:\\Users\\Hugo\\Downloads\\aventOfCode\\02-input.txt"))
{
    var levels = report.Split(' ').Select(lvl => int.Parse(lvl)).ToList();
    bool reportAscending = levels[0] > levels[1];
    bool isSafe = true;
    for (int i = 0; i < levels.Count - 1; i++)
    {
        var diff = Math.Abs(levels[i] - levels[i + 1]);
        var currentlyAscending = levels[i] > levels[i + 1];
        if (diff > 3 || diff < 1 || reportAscending != currentlyAscending)
        {
            isSafe = false; 
            break;
        }
    }
    if (isSafe)
        nbSafeReport++;
}*/

Console.WriteLine(nbSafeReport);

Console.WriteLine("End");
Console.ReadKey();
