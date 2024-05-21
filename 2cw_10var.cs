using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Encodings.Web;

using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;

#region
abstract class Task
{
    protected string text = "";
    public string Text
    {
        get => text;
        protected set => text = value;
    }

    public virtual void Solution() { }
    public Task(string text)
    {
        this.text = text;
    }
}
#endregion 
#region


class Task1 : Task
{
    private char[] answer;
    public char[] Answer
    {
        get => answer;
    }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        answer = Array.Empty<char>(); // Initialize with an empty array
    }
    public override void Solution()
    {
        answer = text
        .ToCharArray()
        .Distinct()
        .Where(c => text.Count(x => x == c) == 1)
        .ToArray();
    }
    public override string ToString()
    {
        Solution();
        if (answer == null) return "";
        return string.Join(", ", answer); ;
    }
}




class Task2 : Task
{
    private string answer;
    public string Answer
    {
        get => answer;
    }
    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        answer = string.Empty; // Initialize with an empty array
    }
    public override void Solution()
    {
        char[] sentenceSeparators = { '.', '!', '?' };
        char[] s = text.Where(c => sentenceSeparators.Contains(c)).ToArray();

        string[] sentences = text.Split(sentenceSeparators);

        for (int i = 0; i < sentences.Length; i++)
        {
            string[] words = sentences[i].Split(' ');
            string reversedSentence = string.Join(" ", words.Reverse());
            answer += reversedSentence + (i >= sentences.Length - 1 ? '\n' : s[i]);
        }
    }
    public override string ToString()
    {
        Solution();
        if (answer == null) return "";
        return answer;
    }
}

#endregion 
class JsonIO
{
    #region для тех, кто хочет максимум, используйте обобщение:
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = false
            };
            JsonSerializer.Serialize(fs, obj, options1);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs);
        }
        return default(T);
    }
    #endregion
}
class Program
{
    static void Main()
    {
        #region Tasks 1,2
        string text = "Объектно ориентированное программиирование — методология на основе описания моделей и их взаимодействия. С джейсоном очень сложно разобраться. В принципе мне нравится программировать, но часто возникают трудности. С ними я пытаюсь справиться. Сегодня я очень старалась.";
        // string text = Console.ReadLine();
        Task[] tasks = {
            new Task1(text),
            new Task2(text),
        };
        Console.WriteLine(tasks[0].ToString());
        Console.WriteLine(tasks[1].ToString());
        #endregion


        #region Файлы
        // string path = @"D:\Temp\csharp_cherep\"; //путь до рабочего стола
        string path = @"C:\Users\user\Desktop"; //путь до рабочего стола
        string folderName = "Answer";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";

        fileName1 = Path.Combine(path, fileName1);
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName1))
        {
            JsonIO.Write<Task1>(tasks[0] as Task1, fileName1);
        }
        else
        {
            var t1 = JsonIO.Read<Task2>(fileName1);
            Console.WriteLine(t1);
        }

        if (!File.Exists(fileName2))
        {
            JsonIO.Write<Task2>(tasks[1] as Task2, fileName2);
        }
        else
        {
            var t2 = JsonIO.Read<Task2>(fileName2);
            Console.WriteLine(t2);
        }

        #endregion

    }
}
