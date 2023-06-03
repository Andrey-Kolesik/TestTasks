public class Solver
{
    public static string[] Calc(string[] source, int index)
    {
        Array.Clear(source, index - 1, 2);
        return source.Where(x => x != null).ToArray();
    }

    static void Main(string[] args)
    {
        string[] charArray;
        charArray = Console.ReadLine().Split(' ');
        foreach (string ch in charArray)
        {
            switch (ch)
            {
                case "+":
                    int indexPlus = Array.IndexOf(charArray, "+");
                    charArray[indexPlus - 2] = (Convert.ToInt32(charArray[indexPlus - 2]) + Convert.ToInt32(charArray[indexPlus - 1])).ToString();
                    charArray = Calc(charArray, indexPlus);
                    break;
                case "-":
                    int indexMinus = Array.IndexOf(charArray, "-");
                    charArray[indexMinus - 2] = (Convert.ToInt32(charArray[indexMinus - 2]) - Convert.ToInt32(charArray[indexMinus - 1])).ToString();
                    charArray = Calc(charArray, indexMinus);
                    break;
                case "*":
                    int indexMultiply = Array.IndexOf(charArray, "*");
                    charArray[indexMultiply - 2] = (Convert.ToInt32(charArray[indexMultiply - 2]) * Convert.ToInt32(charArray[indexMultiply - 1])).ToString();
                    charArray = Calc(charArray, indexMultiply);
                    break;
                case "/":
                    int indexDivision = Array.IndexOf(charArray, "/");
                    charArray[indexDivision - 2] = (Convert.ToInt32(charArray[indexDivision - 2]) / Convert.ToInt32(charArray[indexDivision - 1])).ToString();
                    charArray = Calc(charArray, indexDivision);
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine(charArray[0]);
    }
}