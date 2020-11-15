using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AISpellCorrectRatio : MonoBehaviour
{

    public Text aiScore;

    public RandomWordPicker wordPicker;

    public int point;

    public enum AILevel 
    {
        Newbie,
        Easy,
        Medium,
        Hard,
        Extream
    };

    public bool correctSpelled;

    public AILevel aILevel;
    float gate;

    private void Start() {
    }

    private void Update() {

        aiScore.text = point.ToString();
        
        if(wordPicker.currentState==RandomWordPicker.gameState.aiwritting)
        {
            Ratio();
        }


        if(aILevel == AILevel.Newbie)
        {
            gate = 10;
        }
        if(aILevel == AILevel.Easy)
        {
            gate = 30;
        }
        if(aILevel == AILevel.Medium)
        {
            gate = 50;
        }
        if(aILevel == AILevel.Hard)
        {
            gate = 70;
        }
        if(aILevel == AILevel.Extream)
        {
            gate = 90;
        }
    }

    public void Ratio()
    {
        float k = Random.Range(0f,101f);
        if(k<gate)
        {
            point += 1;
            correctSpelled = true;            
        }
        else{
            correctSpelled = false;
        }
        wordPicker.currentState = RandomWordPicker.gameState.desn;
    }
}
