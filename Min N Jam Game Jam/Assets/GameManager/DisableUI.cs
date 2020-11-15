using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUI : MonoBehaviour
{
    public GameObject[] Uis;
    
    public void DissableUIs()
    {
        foreach(GameObject ui in Uis)
        {
            ui.SetActive(false);
        }
    }
}
