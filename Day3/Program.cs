using System.Text.RegularExpressions;
Console.WriteLine("Day 3 :");

var content = File.ReadAllText("C:\\Users\\Hugo\\Downloads\\aventOfCode\\03-input.txt");

// part1
var matches = Regex.Matches(content, @"mul\((\d{1,3}),(\d{1,3})\)");
var sumPart1 = matches.Where(m  => m.Success).Select(MultiplyMatchValues).Sum();

// part2
var sumPart2 = 0;
var lastWasDo = true;
var lastIndex = 0;
foreach (Match match in matches)
{
    var textBetweenMatches = content.Substring(lastIndex, match.Index - lastIndex);
    lastWasDo = ExtractLastDoOrDont(textBetweenMatches);

    if (lastWasDo)
        sumPart2 += MultiplyMatchValues(match);
    lastIndex = match.Index + match.Length;
}

Console.WriteLine($"Result part1 is {sumPart1}");
Console.WriteLine($"Result part2 is {sumPart2}");
Console.ReadLine();

int MultiplyMatchValues(Match match)
{
    return int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
}

bool ExtractLastDoOrDont(string input)
{
    var matches = Regex.Matches(input, @"do\(\)|don't\(\)");
    return matches.Count == 0 ? lastWasDo : matches[^1].Value == "do()";
}