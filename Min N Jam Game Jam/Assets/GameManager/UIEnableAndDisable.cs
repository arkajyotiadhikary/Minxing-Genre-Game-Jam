using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnableAndDisable : MonoBehaviour
{
    
    public bool enableUI;

    public GameObject inputField;
    public GameObject wordDisplay;

    InputField input;


    // Start is called before the first frame update
    void Start()
    {
        input = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(enableUI)
        {
            input.ActivateInputField();
            inputField.SetActive(true);
            wordDisplay.SetActive(true);
        }
        else{
            StartCoroutine(DisableUI());
        }
    }
    IEnumerator DisableUI()
    {
        inputField.GetComponent<Animator>().SetBool("Disable",true);
        wordDisplay.GetComponent<Animator>().SetBool("Disable",true);
        yield return new WaitForSeconds(1);
        input.text = "";
        inputField.SetActive(false);
        wordDisplay.SetActive(false);
    }
}
