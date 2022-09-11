using System.Text.Json;
namespace BinaryTree;

internal static class FileWorker
{
    public static HashSet<float> GetSet(string path)
    {
        HashSet<float> set;
        StreamReader reader = new StreamReader(path);
        var str = reader.ReadToEnd();
        if (str != "")
        {
            set = JsonSerializer.Deserialize<HashSet<float>>(str)!;
        }
        else
        {
            set = new HashSet<float>();
        }
        reader.Close();
        return set;
    }

    public static void SaveSet(HashSet<float> set, string path) 
    {
        StreamWriter writer = new StreamWriter(path);
        writer.Write(JsonSerializer.Serialize(set));
        writer.Close();
    }
}
