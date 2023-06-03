public class Solver
{
    static void Main(string[] args)
    {
        string[] a = Console.ReadLine().Split(" ");
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        int maxChar = a.Distinct().Max(i => i.Length);

        foreach (string item in a.Distinct())
        {
            keyValuePairs.Add(item, a.Count(i => i == item));
        }

        double maxEntry = keyValuePairs.Values.Max();
        var sortedKeyValuePairs = keyValuePairs.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        foreach (string s in sortedKeyValuePairs.Keys)
        {
            Console.WriteLine($"{s.Insert(0, new string('_', maxChar - s.Length))} " +
                $"{new string('.', Convert.ToInt32(Math.Round(sortedKeyValuePairs[s] * 10 / maxEntry, MidpointRounding.AwayFromZero)))}");
        }
    }
}