using System;
using System.Linq;

public class TextAnalyzer
{
    public int CountWords(string text)
    {
<<<<<<< HEAD
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Split(new[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries).Length;
=======
        // Todo: Implement word count logic
        throw new NotImplementedException();
>>>>>>> assignment/unit-testing
    }

    public int CountLetters(string text)
    {
<<<<<<< HEAD
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return text.Count();
=======
        // Todo: Implement letter count logic
        throw new NotImplementedException();
>>>>>>> assignment/unit-testing
    }
}
