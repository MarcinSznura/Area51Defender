using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI play;
    [SerializeField] TextMeshProUGUI play2;
    [SerializeField] TextMeshProUGUI settings;
    [SerializeField] TextMeshProUGUI settings2;
    [SerializeField] TextMeshProUGUI quit;
    [SerializeField] TextMeshProUGUI quit2;

    private void Start()
    {
        Cursor.visible = true;
    }

    private void OnGUI()
    {
        int lang = FindObjectOfType<MainMenu>().language;
        if (lang == 0)
        {
            play.text = "PLAY";
            play2.text = "PLAY";
            settings.text = "SETTINGS";
            settings2.text = "SETTINGS";
            quit.text = "QUIT";
            quit2.text = "QUIT";
        }
        else
        {
            play.text = "GRAJ";
            play2.text = "GRAJ";
            settings.text = "OPCJE";
            settings2.text = "OPCJE";
            quit.text = "WYJSCIE";
            quit2.text = "WYJSCIE";
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void GameSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
