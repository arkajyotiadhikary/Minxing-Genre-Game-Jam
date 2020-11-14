using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordPicker : MonoBehaviour
{
    public string[] words;
    
    public Text choosedText;


    enum gameState
    {
        choosingWord,
        writingWord
    }

    string choosedWord;
    
    gameState currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == gameState.choosingWord)
        {
            StartCoroutine(ChooseRandomWord());
        }
    }

    IEnumerator ChooseRandomWord()
    {
        choosedWord = words[Random.Range(0,words.Length)];
        choosedText.text = choosedWord;
        currentState = gameState.writingWord;
        yield return new WaitForSeconds(1);
    }
}
