using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 1;
    [SerializeField] ParticleSystem hitParticlePrefab; 
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] AudioClip[] enemyDeathSFX;
    [SerializeField] ParticleSystem flamePrefab;
    [SerializeField] ParticleSystem explosionOnAmmoHit;

    AudioSource myAudioSource;
    bool isBurning = false;
    int playerDamage;
    int incAmmo;
    int droneDamage;
    float soundVolume;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        if (FindObjectOfType<TimeMaster>().wave == 1) hitPoints = 1;
        if (FindObjectOfType<TimeMaster>().wave == 2) hitPoints = 2;
        if (FindObjectOfType<TimeMaster>().wave == 3) hitPoints = 3;
        if (FindObjectOfType<TimeMaster>().wave == 4) hitPoints = 4;
        if (FindObjectOfType<TimeMaster>().wave > 4)
        {
            int hpMultiplayer = FindObjectOfType<TimeMaster>().wave / 5;
            hitPoints = 3 * (hpMultiplayer + 1);
        }

        playerDamage = FindObjectOfType<Upgrademenu>().GetplayerDamage();
        incAmmo = FindObjectOfType<Upgrademenu>().GetammoIncendiary();
        droneDamage = FindObjectOfType<Upgrademenu>().GetbaseDrones();
        soundVolume = FindObjectOfType<MainMenu>().soundsValue;
    }

    void OnParticleCollision(GameObject other)
    {
        switch (other.tag)
        {

            case "marineBullet":
                hitPoints -= FindObjectOfType<Upgrademenu>().GetbaseDamage();
                break;

            case "droneBullet":
                hitPoints -= 5 + FindObjectOfType<Upgrademenu>().GetbaseDrones();
                break;

            case "napalmBullet":
                flamePrefab.Play();
                isBurning = true;
                StartCoroutine(Burning());
                break;

           
        }
        
        hitParticlePrefab.Play();
        if (hitPoints <= 0)
        {
            KillEnemySequence();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("explode"))
        { 
        hitPoints -= FindObjectOfType<Upgrademenu>().GetammoExplosive();
        }

        if (hitPoints <= 0)
        {
            KillEnemySequence();
        }

    }

    public void ProcessDamageRecivedFromAirStrike1()
    {
        hitPoints -= 5;

        if (hitPoints <= 0)
        {
            KillEnemySequence();
        }

    }

    public void ProcessDamageRecivedFromAirStrike2()
    {
            flamePrefab.Play();
            isBurning = true;
            StartCoroutine(Burning());
    }

    public void ProcessDamageRecivedFromDrones()
    {
        hitPoints -= 5 + 2* droneDamage;

        if (hitPoints <= 0)
        {
            KillEnemySequence();
        }
    }

    public void ProcessDamageRecivedFromMarines()
    {
        hitPoints -= 2;

        if (hitPoints <= 0)
        {
            KillEnemySequence();
        }
    }

    public void ProcessDamageRecivedFromPlayer()
    {
        if (CriticalHitHandler())
        {
            hitPoints -= 2*playerDamage;
        }
        else hitPoints -= playerDamage;

        if (hitPoints <= 0)
        {
            KillEnemySequence();
        }

         if (incAmmo > 0 && !isBurning)
         {
             flamePrefab.Play();
             isBurning = true;
             StartCoroutine(Burning());
         }
    }

    bool CriticalHitHandler()
    {
        int critChance = FindObjectOfType<Upgrademenu>().GetammoCritical();
        int rool = Random.Range(0,100);
        if (critChance*5 > rool) return true;
        else return false;
       
    }

    private void KillEnemySequence()
    {
        Instantiate(deathFX, new Vector3 (transform.position.x, transform.position.y+3, transform.position.z), Quaternion.identity);
        var ran = Random.Range(0, 5);
        AudioSource.PlayClipAtPoint(enemyDeathSFX[ran], Camera.main.transform.position, soundVolume * .3f);
        FindObjectOfType<Upgrademenu>().IncreasePlayerExpierience(2);
        FindObjectOfType<GameGUI>().IncreaseBodyCount();
        Destroy(gameObject);
    }


    IEnumerator Burning()
    {
        while (true)
        {
            hitPoints -= incAmmo;
            if (hitPoints <= 0)
            {
                KillEnemySequence();
            }
            yield return new WaitForSeconds(2);
        }
        
    }

}
