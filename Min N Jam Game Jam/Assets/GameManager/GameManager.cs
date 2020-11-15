using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text score;

    public GameObject EndScreen;
    public DisableUI disable;
    // Health
    public Slider playerHealthSlieder;
    public Slider aiHealthSlieder;

    public float playerMaxHealth;
    public float aiMaxHealth;



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
        EndScreen.SetActive(false);
        playerHealthSlieder.maxValue = playerMaxHealth;
        aiHealthSlieder.maxValue = aiMaxHealth;
    }

    // Update is called once per frame
    void Update()
    { 
        score.text = playerSpelling.scorePoint.ToString();

        playerHealthSlieder.value = playerMaxHealth;
        aiHealthSlieder.value = aiMaxHealth;

        if(playerHealthSlieder.value <= 0)
        {
            GameOver();
        }

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
            
            else if(!playerSpelling.spelledCorrect && aiSpelling.correctSpelled)
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
        playerMaxHealth -= 1;
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
        aiMaxHealth -= 1;
        yield return new WaitForSeconds(.1f);
        AIAnimator.SetBool("Hit_bool",false);
        playerAnim.SetBool("Box_bool",false);
    }

    void GameOver()
    {
        disable.DissableUIs();
        EndScreen.SetActive(true);
    }
}
