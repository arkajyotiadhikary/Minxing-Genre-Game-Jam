using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellingCheck : MonoBehaviour
{

    public bool spelledCorrect;

    public InputField inputField;
    public Text score;

    int scorePoint;

    public AISpellCorrectRatio aiSpelling;

    public RandomWordPicker wordPicker;
    public UIEnableAndDisable uIEnableAndDisable;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scorePoint.ToString();

        if(inputField.text.Length == wordPicker.choosedWord.Length)
        {
            if(inputField.text[inputField.text.Length-1] == wordPicker.choosedWord[wordPicker.choosedWord.Length-1])
            {
                // aiSpelling.Ratio();
                wordPicker.currentState = RandomWordPicker.gameState.aiwritting;
                scorePoint += 1;
                inputField.text = "";
                spelledCorrect = true;
                uIEnableAndDisable.enableUI = false;
            }
        }

        for(var i=0;i<inputField.text.Length;i++)
        {
            if(inputField.text[i] != wordPicker.choosedWord[i])
            {
                // aiSpelling.Ratio();
                uIEnableAndDisable.enableUI = false;
                wordPicker.currentState = RandomWordPicker.gameState.aiwritting;
            }
        }
    }
}
