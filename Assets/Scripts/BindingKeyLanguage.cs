using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BindingKeyLanguage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI up;
    [SerializeField] TextMeshProUGUI down;
    [SerializeField] TextMeshProUGUI right;
    [SerializeField] TextMeshProUGUI left;
    [SerializeField] TextMeshProUGUI fire;
    [SerializeField] TextMeshProUGUI skill1;
    [SerializeField] TextMeshProUGUI skill2;
    [SerializeField] TextMeshProUGUI back;
    [SerializeField] TextMeshProUGUI back2;

    private void OnGUI()
    {
        int lang = FindObjectOfType<MainMenu>().language;
        if (lang == 0)
        {
            up.text = "UP";
            down.text = "DOWN";
            right.text = "RIGHT";
            left.text = "LEFT";
            fire.text = "FIRE";
            skill1.text = "SKILL 1";
            skill2.text = "SKILL 2";
            back.text = "BACK";
            back2.text = "BACK";
        }
        else
        {
            up.text = "GORA";
            down.text = "DOL";
            right.text = "PRAWO";
            left.text = "LEWO";
            fire.text = "STRZAL";
            skill1.text = "UMIEJ. 1";
            skill2.text = "UMIEJ. 2";
            back.text = "COFNIJ";
            back2.text = "COFNIJ";
        }
    }
}
