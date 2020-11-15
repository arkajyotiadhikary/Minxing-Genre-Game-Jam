using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 10;
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
    }

    public IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(1);
        timeLeft = maxTime;
    }
}
