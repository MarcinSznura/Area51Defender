using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseTranslator : MonoBehaviour
{

    [Header("Labels")]
    [SerializeField] TextMeshProUGUI areYouSureText;
    [SerializeField] TextMeshProUGUI continueButton;
    [SerializeField] TextMeshProUGUI exitButton;

    void Start()
    {
        
    }

    public void SetPauseMenuLanguage(int lang)
    {
        if (lang == 0)
        {
            string areYouSureTextString = "CONFIRM GAME CLOSING";
            string continueButtonString = "CONTINUE";
            string exitButtonString = "EXIT";


            areYouSureText.text = areYouSureTextString;
            continueButton.text = continueButtonString;
            exitButton.text = exitButtonString;

           
        }
        else
        {
            string areYouSureTextString = "POTWIERDZ ZAMKNIECIE GRY";
            string continueButtonString = "GRAJ DALEJ";
            string exitButtonString = "ZAMKNIJ GRE";




            areYouSureText.text = areYouSureTextString;
            continueButton.text = continueButtonString;
            exitButton.text = exitButtonString;

 
        }


    }
}
