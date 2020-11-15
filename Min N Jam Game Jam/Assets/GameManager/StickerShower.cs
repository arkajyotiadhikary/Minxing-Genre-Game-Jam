using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerShower : MonoBehaviour
{
    public GameObject right;
    public GameObject wrong;

    public GameObject aiRight;
    public GameObject aiWrong;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator dissAble()
    {
        right.SetActive(false);
        wrong.SetActive(false);
        yield return new WaitForSeconds(2);
        aiRight.SetActive(false);
        aiWrong.SetActive(false);
        yield return new WaitForSeconds(2);
    }
}
