using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI quit;
    [SerializeField] TextMeshProUGUI quit2;

    private void OnGUI()
    {
        int lang = FindObjectOfType<MainMenu>().language;
        if (lang == 0)
        {
            quit.text = "BACK";
            quit2.text = "BACK";
        }
        else
        {
            quit.text = "COFNIJ";
            quit2.text = "COFNIJ";
        }
    }

    public void GameSettings()
    {
        SceneManager.LoadScene(1);
    }

}
