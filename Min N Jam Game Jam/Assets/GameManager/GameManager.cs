using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject right;
    public GameObject wrong;


    public StickerShower sticker;

    public CameraShake camera;
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
            // if(playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
            // {
            //     StartCoroutine(timer.ResetTimer());
            //     uIEnableAndDisable.enableUI = true;
            //     playerSpelling.spelledCorrect = false;
            //     wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
            //     StartCoroutine(sticker.dissAble());
            // }
            if(playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
            {
                // right.SetActive(true);
                wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
                StartCoroutine(timer.ResetTimer());
                uIEnableAndDisable.enableUI = true;
                playerSpelling.spelledCorrect = false;
                aiSpelling.correctSpelled = false;
                StartCoroutine(sticker.dissAble());
            }
            
            if(!playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
            {
                // right.SetActive(true);
                StartCoroutine(timer.ResetTimer());
                StartCoroutine(playerHit());
                StartCoroutine(sticker.dissAble());

            }
            else if(playerSpelling.spelledCorrect && !aiSpelling.correctSpelled)
            {
                // wrong.SetActive(true);
                StartCoroutine(timer.ResetTimer());
                StartCoroutine(aiHit());
                StartCoroutine(sticker.dissAble());
            }
            else
            {
                // wrong.SetActive(true);
                wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
                StartCoroutine(timer.ResetTimer());
                uIEnableAndDisable.enableUI = true;
                playerSpelling.spelledCorrect = false;
                aiSpelling.correctSpelled = false;
                StartCoroutine(sticker.dissAble());
            }
        }
    }

    IEnumerator playerHit()
    {
        playerSpelling.spelledCorrect = false;
        aiSpelling.correctSpelled = false;
        wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
        uIEnableAndDisable.enableUI = true;
        AIAnimator.SetBool("Box_bool",true);
        playerAnim.SetBool("Hit_bool",true);
        camera.ShakeIt();
        yield return new WaitForSeconds(.1f);
        AIAnimator.SetBool("Box_bool",false);
        playerAnim.SetBool("Hit_bool",false);
       
    }
    IEnumerator aiHit()
    {
        playerSpelling.spelledCorrect = false;


        wordPicker.currentState = RandomWordPicker.gameState.choosingWord;
        uIEnableAndDisable.enableUI = true;
        aiSpelling.correctSpelled = false;
        AIAnimator.SetBool("Hit_bool",true);
        playerAnim.SetBool("Box_bool",true);
        camera.ShakeIt();
        yield return new WaitForSeconds(.1f);
        AIAnimator.SetBool("Hit_bool",false);
        playerAnim.SetBool("Box_bool",false);
    }
}
