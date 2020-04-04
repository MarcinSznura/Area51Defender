using System;
using System.Collections;
using UnityEngine;

public class MarineTargeting : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 50f;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip lastGunShot;

    Transform targetEnemy;
    bool canIFire = true;
    int fireRate;
    int damage;
    float soundVolume;

    private void Start()
    {
        SetMarineParameters();
        soundVolume = FindObjectOfType<MainMenu>().soundsValue;
    }

    public void SetMarineParameters()
    {
        fireRate = FindObjectOfType<Upgrademenu>().GetbaseFireRate();
        damage = FindObjectOfType<Upgrademenu>().GetbaseDamage();
    }

    void Update()
    {
        if (canIFire)
        {
            Debug.Log("i can fire");
            if (SetTargetEnemy() != null)
            {
                targetEnemy = SetTargetEnemy().transform;
                objectToPan.LookAt(targetEnemy);
                FireAtEnemy();
            }
        }
    
    }

    public EnemyDamage SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return null; }

        Transform closestEnemy = sceneEnemies[0].transform;
        int numberOfClosestEnemy = -1;
        int i = 0;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
            if (closestEnemy == testEnemy.transform && closestEnemy.transform.position.x < 100) numberOfClosestEnemy = i;
            i++;
        }
        if (numberOfClosestEnemy == -1) return null;
        else return sceneEnemies[numberOfClosestEnemy];
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distToA = Vector3.Distance(transform.position, transformA.position);
        var distToB = Vector3.Distance(transform.position, transformB.position);

        if (distToA < distToB)
        {
            return transformA;
        }

        return transformB;
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distanceToEnemy <= attackRange)
        {
            StartCoroutine(Shoot());
        }
      
    }

    IEnumerator Shoot()
    {
        canIFire = false;
        for (int i = 0; i < damage; i++)
        {
            if (SetTargetEnemy() != null)
            {
                EnemyDamage target = SetTargetEnemy();
                muzzleFlash.Emit(1);
                Instantiate(projectileParticle, new Vector3(target.transform.position.x, target.transform.position.y + 3, target.transform.position.z), Quaternion.identity);
                if (i == damage - 1) GetComponent<AudioSource>().PlayOneShot(lastGunShot,soundVolume * .6f);
                else GetComponent<AudioSource>().PlayOneShot(gunShot);
                target.ProcessDamageRecivedFromMarines();
            }
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(3f/fireRate);
        canIFire = true;
    }
}