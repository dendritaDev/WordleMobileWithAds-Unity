using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private string secretWord;
    [SerializeField] TextAsset wordsText;
    private string words;
    List<string> wordsList = new List<string>();

    [Header(" Settings ")]
    private bool shouldReset;

    public static WordManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        words = wordsText.text;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (wordsText != null)
        {
            string[] wordArray = wordsText.text.Split("\r\n"); //con esto quitamos el espacio y el enter
            foreach (string word in wordArray)
            {
                // Asegúrate de que la palabra tenga exactamente 5 letras antes de agregarla
                if (word.Length == 5)
                {
                    wordsList.Add(word.Trim()); // Elimina espacios en blanco
                }
            }
        }


        SetNewSecretWord();

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
                if (shouldReset)
                    SetNewSecretWord();

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

    public string GetSecretWord()
    {
        return secretWord.ToUpper();
    }

    private void SetNewSecretWord()
    {
        // - - PRIMERA MANERA - -
        ////Cada linea son 7 carácteres: 5 de la palabra + espacio + enter
        ////Excepto en la ultima linea que no hay ni espacio ni enter por eso le sumamos 2 antes de diviidrlo entre 7, para que 
        ////no nos de decimales
        //int wordCount = (words.Length + 2) / 7;

        //int wordIndex = Random.Range(0, wordCount); //cogemos un numero random del total de palabras

        //int wordStartIndex = wordIndex * 7; //lo multiplicamos por 7 para obtener la linea en nuestro textAsset que se corresponde a esa palabra

        //secretWord = words.Substring(wordStartIndex, 5).ToUpper(); ;

        // - - MEJOR MANERA - -
        if (wordsList.Count > 0)
        {
            int randomIndex = Random.Range(0, wordsList.Count);
            secretWord = wordsList[randomIndex].ToUpper();
        }

        shouldReset = false;

    }
}
