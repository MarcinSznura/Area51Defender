using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip healthDamageSFX;
    
    public void BaseReached()
    {
        playerHealth -= healthDecrease;
        GetComponent<AudioSource>().PlayOneShot(healthDamageSFX);
        FindObjectOfType<GameGUI>().RefreshUI();
        if (playerHealth <= 0) SceneManager.LoadScene(0);
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

}
