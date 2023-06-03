public class ListNode<T>
{
    public int Value { get; set; }
    public ListNode<T>? Next { get; set; }

    public void Insert(int newValue)
    {
        Value = newValue;
    }
}

class HashTable
{
    public ListNode<int>[] values;

    public HashTable(int listNodeSize)
    {
        values = new ListNode<int>[listNodeSize];
    }

    public void insertItem(int newValue)
    {
        int index = hashFunction(newValue);
        ListNode<int> listNode = values[index];

        if (listNode == null)
        {
            values[index] = new ListNode<int>() { Value = newValue };
            return;
        }

        while (listNode.Next != null)
        {
            listNode = listNode.Next;
        }

        ListNode<int> newListNode = new ListNode<int>() { Value = newValue };
        listNode.Next = newListNode;
    }

    int hashFunction(int item)
    {
        return (item % values.Length);
    }

}

class Program
{
    static void Main(string[] args)
    {

        int a = Convert.ToInt32(Console.ReadLine());
        int[] b = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        HashTable hashTable = new HashTable(a);
        for (int i = 0; i < b.Length; i++)
            hashTable.insertItem(b[i]);
        for (int i = 0; i < a; i++)
        {
            var item = hashTable.values[i];
            Console.Write($"{i}: ");
            while (item != null)
            {
                Console.Write($"{item.Value} ");
                item = item.Next;
            }
            Console.WriteLine();

        }
    }
}