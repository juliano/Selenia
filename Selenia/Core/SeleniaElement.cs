﻿using OpenQA.Selenium;

namespace Selenia.Core
{
    public interface SeleniaElement : IWebElement
    {
        string Value();

        SeleniaElement Value(string text);

        SeleniaElement Enter();

        bool Exists();

        new bool Displayed { get; }

        SeleniaElement Append(string text);

        string Data(string dataAttribute);

        string Name { get; }

        string Attr(string name);
    }
}