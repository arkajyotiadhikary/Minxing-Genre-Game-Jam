using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellingCheck : MonoBehaviour
{

    // images
    public GameObject right;
    public GameObject wrong;

    public bool spelledCorrect;

    public InputField inputField;
    public Text score;

    int scorePoint;

    public AISpellCorrectRatio aiSpelling;

    public RandomWordPicker wordPicker;
    public UIEnableAndDisable uIEnableAndDisable;

    void Start()
    {
        right.SetActive(false);
        wrong.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = scorePoint.ToString();

        if(inputField.text.Length == wordPicker.choosedWord.Length)
        {
            if(inputField.text[inputField.text.Length-1] == wordPicker.choosedWord[wordPicker.choosedWord.Length-1])
            {
                StartCoroutine(rightSpell());
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
                StartCoroutine(wrongeSpell());
                uIEnableAndDisable.enableUI = false;
                break;
            }
        }
    }

    IEnumerator rightSpell()
    {
        right.SetActive(true);
        yield return new WaitForSeconds(2);
        wordPicker.currentState = RandomWordPicker.gameState.aiwritting;
    }
    IEnumerator wrongeSpell()
    {
        wrong.SetActive(true);
        yield return new WaitForSeconds(2);
        wordPicker.currentState = RandomWordPicker.gameState.aiwritting;
    }
    
}
