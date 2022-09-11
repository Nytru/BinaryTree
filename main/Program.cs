using BinaryTree;

Tree<float> tree = new();
List<int> arr = new();


foreach (var a in Enumerable.Range(0, 25))
{
    var r = new Random();
    var num = r.Next(0, 200);
    tree.Add(num);
    arr.Add(num);
}

foreach (var v in arr)
{
    Console.WriteLine(v);
}

