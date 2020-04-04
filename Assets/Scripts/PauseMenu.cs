using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;

    void Start()
    {
        pauseCanvas.enabled = false;
        int lang = FindObjectOfType<MainMenu>().language;
        FindObjectOfType<PauseTranslator>().SetPauseMenuLanguage(lang);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseCanvas.enabled)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseCanvas.enabled = true;
        Cursor.visible = true;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseCanvas.enabled = false;
        Cursor.visible = false;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
