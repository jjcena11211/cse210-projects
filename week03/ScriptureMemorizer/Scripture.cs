using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (string part in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            _words.Add(new Word(part));
        }
    }

    // Hides up to numberToHide words, choosing only from words that are
    // still visible (stretch requirement).
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visible = _words.Where(w => !w.IsHidden()).ToList();
        int count = Math.Min(numberToHide, visible.Count);

        for (int i = 0; i < count; i++)
        {
            int index = _random.Next(visible.Count);
            visible[index].Hide();
            visible.RemoveAt(index);
        }
    }

    public void ShowAllWords()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public int GetHiddenPercent()
    {
        int hidden = _words.Count(w => w.IsHidden());
        return hidden * 100 / _words.Count;
    }
}
