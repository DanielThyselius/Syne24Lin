using System;
using System.Linq;

public class TextAnalyzer
{
    public int CountWords(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Split(new[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public int CountLetters(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Count();
    }
}
