using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _baseWord;
    
    public Anagram(string baseWord) => this._baseWord = baseWord;

    public string[] FindAnagrams(string[] potentialMatches) =>
        potentialMatches
            .Where(x => !string.Equals(x.ToLower(), _baseWord.ToLower()))
            .Where(y => string.Equals(
                new string(y.ToLower().OrderBy(x => x).ToArray()), 
                new string(_baseWord.ToLower().OrderBy(x => x).ToArray())))
            .ToArray();
}