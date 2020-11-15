using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StickerShower sticker;

    public SpellingCheck playerSpelling;
    public RandomWordPicker wordPicker;
    public UIEnableAndDisable uIEnableAndDisable;
    public AISpellCorrectRatio aiSpelling;
    public Timer timer;

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
                StartCoroutine(timer.ResetTimer());
                uIEnableAndDisable.enableUI = true;
                playerSpelling.spelledCorrect = false;
                wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
                StartCoroutine(sticker.dissAble());
            }
            else if(!playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
            {
               
                StartCoroutine(timer.ResetTimer());
                StartCoroutine(playerHit());
                StartCoroutine(sticker.dissAble());

            }
            else if(playerSpelling.spelledCorrect && !aiSpelling.correctSpelled)
            {
                StartCoroutine(timer.ResetTimer());
                StartCoroutine(aiHit());
                StartCoroutine(sticker.dissAble());
               
            }
            else
            {
                StartCoroutine(timer.ResetTimer());
                uIEnableAndDisable.enableUI = true;
                playerSpelling.spelledCorrect = false;
                wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
                StartCoroutine(sticker.dissAble());

            }
        }
    }

    IEnumerator playerHit()
    {
        playerSpelling.spelledCorrect = false;
        wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
        uIEnableAndDisable.enableUI = true;
        AIAnimator.SetBool("Box_bool",true);
        playerAnim.SetBool("Hit_bool",true);
        yield return new WaitForSeconds(1);
        AIAnimator.SetBool("Box_bool",false);
        playerAnim.SetBool("Hit_bool",false);
       
    }
    IEnumerator aiHit()
    {
        playerSpelling.spelledCorrect = false;
        wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
        uIEnableAndDisable.enableUI = true;
    
        AIAnimator.SetBool("Hit_bool",true);
        playerAnim.SetBool("Box_bool",true);
        yield return new WaitForSeconds(1);
        AIAnimator.SetBool("Hit_bool",false);
        playerAnim.SetBool("Box_bool",false);
    }
}
