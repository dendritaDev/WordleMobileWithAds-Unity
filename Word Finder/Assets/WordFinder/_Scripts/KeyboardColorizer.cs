using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardColorizer : MonoBehaviour
{
    [Header(" Elements ")]
    private KeyboardKey[] keys;

    [Header(" Settings")]
    private bool shouldReset;

    private void Awake()
    {
        keys = GetComponentsInChildren<KeyboardKey>();
    }



    // Start is called before the first frame update
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;

    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {

        switch (gameState)
        {
            case GameState.Menu:
                break;
            case GameState.Game:
                if(shouldReset)
                    Initialize();
                break;
            case GameState.LevelComplete:
                shouldReset = true;
                break;
            case GameState.Gameover:
                shouldReset = true;
                break;
            case GameState.Idle:
                break;
            default:
                break;
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].Initialize();
        }
        shouldReset = false;
    }

    public void Colorize(string secretWord, string wordToCheck)
    {
        for (int i = 0; i < keys.Length; i++) //cogemos todas las letras del teclado
        {
            char keyLetter = keys[i].GetLetter();

            for (int j = 0; j < wordToCheck.Length; j++) //miramos cuales letras del teclado coinciden con la palabra que hemos escrito
            {
                if (keyLetter != wordToCheck[j])
                    continue;


                //miramos si de las letras que hemos pulsado en el teclado, alguna coincide, potencialmente podria coincidir o no coincide con la secretWord

                if(keyLetter == secretWord[j]) //contiene en esa posicion
                {
                    keys[i].SetValid();
                }
                else if(secretWord.Contains(keyLetter)) //tiene esa letra
                {
                    keys[i].SetPotential();
                }
                else //no tiene
                {
                    keys[i].SetInvalid();
                }

            }
        }
    }
}
