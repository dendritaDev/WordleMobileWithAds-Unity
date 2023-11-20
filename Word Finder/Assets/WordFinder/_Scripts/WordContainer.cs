using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordContainer : MonoBehaviour
{
    [Header(" Elements ")]
    private LetterContainer[] letterContainers;

    [Header(" Settings")]
    private int currentLetterIndex;

    private void Awake()
    {
        letterContainers = GetComponentsInChildren<LetterContainer>();

        //Initialize();
    }

    public void Initialize()
    {
        currentLetterIndex = 0;

        for (int i = 0; i < letterContainers.Length; i++)
        {
            letterContainers[i].Initialize();
        }
    }

    internal bool IsComplete()
    {
        return currentLetterIndex >= 5;
    }

    internal void Add(char letter)
    {
        letterContainers[currentLetterIndex].SetLetter(letter);
        currentLetterIndex++;
    }
    internal void AddAsHint(int letterIndex, char letter)
    {
        letterContainers[letterIndex].SetLetter(letter, true);
    }

    internal string GetWord()
    {
        string word = "";

        for (int i = 0; i < letterContainers.Length; i++)
        {
            word += letterContainers[i].GetLetter().ToString();
        }

        return word;
    }


    internal bool RemoveLetter()
    {
        if (currentLetterIndex <= 0)
            return false;

        currentLetterIndex--;
        letterContainers[currentLetterIndex].Initialize();
        return true;
    }

    internal void Colorize(string secretWord)
    {

        List<char> chars = new List<char>(secretWord.ToCharArray());

        for (int i = 0; i < letterContainers.Length; i++)
        {
            char letterToCheck = letterContainers[i].GetLetter();

            if(letterToCheck == secretWord[i]) //coincide
            {
                letterContainers[i].SetValid();
                chars.Remove(letterToCheck); //esto es para que solo marque una vez si hemos encontrado una letra
            }
            else if(chars.Contains(letterToCheck)) //tiene la letra pero no en esa posicion
            {
                letterContainers[i].SetPotential();
                chars.Remove(letterToCheck);
            }
            else //no tiene la letra
            {
                letterContainers[i].SetInvalid();
            }
        }
    }

}
