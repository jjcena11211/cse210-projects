using System;
using System.Text;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Replace letters/digits with underscores but keep punctuation,
        // so "trust," becomes "_____," and the verse stays readable.
        StringBuilder hidden = new StringBuilder();
        foreach (char c in _text)
        {
            hidden.Append(char.IsLetterOrDigit(c) ? '_' : c);
        }
        return hidden.ToString();
    }
}
