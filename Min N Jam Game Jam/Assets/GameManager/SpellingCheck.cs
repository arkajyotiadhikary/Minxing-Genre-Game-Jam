using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellingCheck : MonoBehaviour
{

    public AudioClip rightAns;
    public AudioClip wrongAns;

    public AudioSource playerAud;
    

    // images
    public GameObject right;
    public GameObject wrong;

    public bool spelledCorrect;

    public InputField inputField;
    public Text score;

    public int scorePoint;

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
                scorePoint += 1;
                StartCoroutine(rightSpell());
                inputField.text = "";
                spelledCorrect = true;
                uIEnableAndDisable.enableUI = false;
            }
        }

        for(var i=0;i<inputField.text.Length;i++)
        {
            if(inputField.text[i] != wordPicker.choosedWord[i])
            {
                wrn();        
            }
        }
    }

    IEnumerator rightSpell()
    {
        right.SetActive(true);
        playerAud.PlayOneShot(rightAns);
        yield return new WaitForSeconds(2);
        wordPicker.currentState = RandomWordPicker.gameState.aiwritting;
    }
    IEnumerator wrongeSpell()
    {
        playerAud.PlayOneShot(wrongAns);
        wrong.SetActive(true);
        yield return new WaitForSeconds(2);
        wordPicker.currentState = RandomWordPicker.gameState.aiwritting;
    }

    public void wrn()
    {
        StartCoroutine(wrongeSpell());
        inputField.text = "";
        spelledCorrect = false;
        uIEnableAndDisable.enableUI = false;
    }
}
