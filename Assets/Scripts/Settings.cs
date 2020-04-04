using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public Slider soundsSlider;
    public Slider musicSlider;
       
    public float soundsValue;
    public float musicValue;

    [SerializeField] TextMeshProUGUI keyBinding;
    [SerializeField] TextMeshProUGUI keyBinding2;
    [SerializeField] TextMeshProUGUI languageLabel;
    [SerializeField] TextMeshProUGUI languageLabel2;
    [SerializeField] TextMeshProUGUI credits;
    [SerializeField] TextMeshProUGUI credits2;
    [SerializeField] TextMeshProUGUI back;
    [SerializeField] TextMeshProUGUI back2;

    private void Start()
    {
        musicValue = FindObjectOfType<MainMenu>().musicValue;
        soundsValue = FindObjectOfType<MainMenu>().soundsValue;
        musicSlider.value = musicValue;
        soundsSlider.value = soundsValue;
    }

    private void OnGUI()
    {
        int lang = FindObjectOfType<MainMenu>().language;
        if (lang == 0)
        {
            keyBinding.text = "KEY BINDING";
            keyBinding2.text = "KEY BINDING";
            languageLabel.text = "LANGUAGE";
            languageLabel2.text = "LANGUAGE";
            credits.text = "CREDITS";
            credits2.text = "CREDITS";
            back.text = "BACK";
            back2.text = "BACK";
        }
        else
        {
            keyBinding.text = "STEROWANIE";
            keyBinding2.text = "STEROWANIE";
            languageLabel.text = "JEZYK";
            languageLabel2.text = "JEZYK";
            credits.text = "AUTORZY";
            credits2.text = "AUTORZY";
            back.text = "COFNIJ";
            back2.text = "COFNIJ";
        }
    }

    public void KeyBinding()
    {
        UpdateVariables();
        SceneManager.LoadScene(2);
    }

    public void BackToMainMenu()
    {
        UpdateVariables();
        SceneManager.LoadScene(0);
    }

    private void UpdateVariables()
    {
        FindObjectOfType<MainMenu>().musicValue = musicValue;
        FindObjectOfType<MainMenu>().soundsValue = soundsValue;
    }

    public void GoToCredits()
    {
        UpdateVariables();
        SceneManager.LoadScene(4);
    }

    public void MusicChange()
    {
        musicValue = musicSlider.value;
        Debug.Log("Music value is: "+musicValue);
    }

    public void SoundsChange()
    {
        soundsValue = soundsSlider.value;
        Debug.Log("Sounds value is: " + soundsValue);
    }

    public void ChangeLanguage(int lang)
    {
        if (lang == 0)
        {
            FindObjectOfType<MainMenu>().language = 0;
        }
        else
        {
            FindObjectOfType<MainMenu>().language = 1;
        }
    }
}
