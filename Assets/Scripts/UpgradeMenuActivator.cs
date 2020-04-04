using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeMenuActivator : MonoBehaviour
{
    [SerializeField] Canvas canvas1;
    [SerializeField] Canvas canvas2;
    [SerializeField] Canvas canvas3;
    [SerializeField] Text stageClear;
    [SerializeField] Canvas Next_PrevPages;
    [SerializeField] TextMeshProUGUI wave;
    [SerializeField] TextMeshProUGUI expText;
    [SerializeField] TextMeshProUGUI nextWave;

    [SerializeField] Canvas currentCanvas;

    bool isUpgradeMenuActive = false;
    [SerializeField] int currPage;
    [SerializeField] int lang;
    int exp;

    HintPopup[] hints;

    void Start()
    {
        
        currentCanvas = canvas1;
        currPage = 1;
        hints = FindObjectsOfType<HintPopup>();
        lang = FindObjectOfType<MainMenu>().language;
        if (lang == 0)
        {
            nextWave.text = "NEXT  \nWAVE";
        }
        else
        {
            nextWave.text = "NOWA  \n FALA";
        }
        FindObjectOfType<UpgradeTranslator>().SetSkillLanguage(lang);
    }

    void Update()
    {
        
        if (lang == 0)
        {
            wave.text = "WAVE: " + FindObjectOfType<TimeMaster>().wave.ToString();
            expText.text = "CREDITS: " + FindObjectOfType<Upgrademenu>().GetPlayerExp().ToString();
        }
        else
        {
            wave.text = "FALA: " + FindObjectOfType<TimeMaster>().wave.ToString();
            expText.text = "KREDYTY: " + FindObjectOfType<Upgrademenu>().GetPlayerExp().ToString();
        }

        if (isUpgradeMenuActive)
        {
            Cursor.visible = true;
            currentCanvas.enabled = true;
            Next_PrevPages.enabled = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }


    public void ActivateUpgradeMenu(bool flip)
    {
        if(flip == true)
        {
            isUpgradeMenuActive = true;
            

            foreach(HintPopup hint in hints)
            {
                hint.hintsActive(true);
            }
        }
        else
        {
           isUpgradeMenuActive = false;

            foreach (HintPopup hint in hints)
            {
                hint.hintsActive(false);
            }
        }
        
    }

    private void OnlyCurrCanvasVisible(int currCanvas)
    {
        canvas1.enabled = false;
        canvas2.enabled = false;
        canvas3.enabled = false;

        switch (currCanvas)
        {
            case 1:
                currentCanvas = canvas1;
                break;

            case 2:
                currentCanvas = canvas2;
                break;

            case 3:
                currentCanvas = canvas3;
                break;
        }
    }




   

    public void Page1()
    {
        OnlyCurrCanvasVisible(1);
        currPage = 1;
        currentCanvas.enabled = true;
    }

    public void Page2()
    {
        OnlyCurrCanvasVisible(2);
        currPage = 2;
        currentCanvas.enabled = true;
    }

    public void Page3()
    {
        OnlyCurrCanvasVisible(3);
        currPage = 3;
        currentCanvas.enabled = true;
    }


}
