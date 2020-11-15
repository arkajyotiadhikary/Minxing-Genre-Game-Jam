using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public SpellingCheck playerSpell;

    public float maxTime = 30;
    public float timeLeft = 0;

    public Text timerText;

    void Start()
    {
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft >= 0 && timeLeft<=maxTime)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = ((int)timeLeft).ToString();
        }
        if(timeLeft<=0)
        {
            playerSpell.wrn();
            timeLeft = maxTime;
        }
    }
    public IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(1);
        timeLeft = maxTime;
    }
}
