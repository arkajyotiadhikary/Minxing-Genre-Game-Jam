using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWordPicker : MonoBehaviour
{
    public string[] words;
    
    public Text choosedText;


    public enum gameState
    {
        choosingWord,
        writingWord,
        aiwritting,
        desn
    }

    public string choosedWord;
    
    public gameState currentState;

    // Update is called once per frame
    void Update()
    {
        if(currentState == gameState.choosingWord)
        {
            StartCoroutine(ChooseRandomWord());
            choosedWord = words[Random.Range(0,words.Length)];
            currentState = gameState.writingWord;
        }
    }

    public IEnumerator ChooseRandomWord()
    {
        yield return new WaitForSeconds(1);
        choosedText.text = choosedWord;
    }
}
