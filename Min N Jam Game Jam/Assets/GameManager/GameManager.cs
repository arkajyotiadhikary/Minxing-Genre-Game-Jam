using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpellingCheck playerSpelling;
    public RandomWordPicker wordPicker;
    public UIEnableAndDisable uIEnableAndDisable;
    public AISpellCorrectRatio aiSpelling;


    public Animator playerAnim;
    public Animator AIAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(wordPicker.currentState == RandomWordPicker.gameState.desn)
        {
            if(playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
            {
                uIEnableAndDisable.enableUI = true;
                playerSpelling.spelledCorrect = false;
                wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
            }
            else if(!playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
            {
                StartCoroutine(playerHit());
            }
            else if(playerSpelling.spelledCorrect && !aiSpelling.correctSpelled)
            {
                StartCoroutine(aiHit());
            }
            else
            {
                uIEnableAndDisable.enableUI = true;
                playerSpelling.spelledCorrect = false;
                wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
            }
        }
    }

    IEnumerator playerHit()
    {
        AIAnimator.SetBool("Box_bool",true);
        playerAnim.SetBool("Hit_bool",true);
        playerSpelling.spelledCorrect = false;
        yield return new WaitForSeconds(1);
        AIAnimator.SetBool("Box_bool",false);
        playerAnim.SetBool("Hit_bool",false);
        wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
        uIEnableAndDisable.enableUI = true;
    }
    IEnumerator aiHit()
    {
        AIAnimator.SetBool("Hit_bool",true);
        playerAnim.SetBool("Box_bool",true);
        playerSpelling.spelledCorrect = false;
        yield return new WaitForSeconds(1);
        AIAnimator.SetBool("Hit_bool",false);
        playerAnim.SetBool("Box_bool",false);
        wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
        uIEnableAndDisable.enableUI = true;
    }
}
