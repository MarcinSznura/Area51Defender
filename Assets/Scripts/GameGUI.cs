using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameGUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killsLabel;
    [SerializeField] TextMeshProUGUI waveLabel;
    [SerializeField] TextMeshProUGUI aliensLabel;

    int wave, aliens;
    private int bodyCount = 0;

    private void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        wave = FindObjectOfType<TimeMaster>().wave;
        aliens = FindObjectOfType<PlayerHealth>().GetPlayerHealth();
    }

    private void OnGUI()
    {
        int lang = FindObjectOfType<MainMenu>().language;
        if (lang == 0)
        {
            killsLabel.text = "KILLS: "+bodyCount.ToString();
            waveLabel.text = "WAVE: " + wave.ToString();
            aliensLabel.text = "ALIENS: " + aliens.ToString();
        }
        else
        {
            killsLabel.text = "ZABICI: " + bodyCount.ToString();
            waveLabel.text = "FALA: " + wave.ToString();
            aliensLabel.text = "KOSMICI: " + aliens.ToString();
        }
    }

    public void IncreaseBodyCount()
    {
        bodyCount++;
    }
}
