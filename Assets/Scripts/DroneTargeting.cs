using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneTargeting : MonoBehaviour
{

    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] int maxBullets = 15;
    [SerializeField] int currentBullets = 15;
    [SerializeField] Transform gun1;
    [SerializeField] Transform gun2;
    [SerializeField] ParticleSystem muzzle1;
    [SerializeField] ParticleSystem muzzle2;
    [SerializeField] AudioClip gunShot;

    bool readyToLoadBullets = true;
    float soundVolume;

    DroneMovement drone;

    private void Start()
    {
        drone = GetComponent<DroneMovement>();
        soundVolume = FindObjectOfType<MainMenu>().soundsValue;
    }

    public Transform SetTransformOfTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return null; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }
        return closestEnemy;
    }

    public EnemyDamage SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();
        if (sceneEnemies.Length == 0) { return null; }

        Transform closestEnemy = sceneEnemies[0].transform;
        int numberOfClosestEnemy = 0;
        int i = 0;

        foreach (EnemyDamage testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
            if (closestEnemy == testEnemy.transform) numberOfClosestEnemy = i;
                i++;
        }
        return sceneEnemies[numberOfClosestEnemy];
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

    public void Shooting()
    {
        if (SetTargetEnemy() != null && currentBullets > 0)
        {
            EnemyDamage target = SetTargetEnemy();
            gun1.LookAt(target.transform);
            gun2.LookAt(target.transform);
            muzzle1.Emit(1);
            muzzle2.Emit(1);
            GetComponent<AudioSource>().PlayOneShot(gunShot, soundVolume * .2f);
            Instantiate(projectileParticle, target.transform.position, Quaternion.identity);
            currentBullets--;
            target.ProcessDamageRecivedFromDrones();
        }
        if (currentBullets <= 0) drone.state = DroneMovement.States.fallingOUT;
    }

    public void Reloading()
    {
        if (currentBullets < maxBullets && readyToLoadBullets)
        {
            StartCoroutine(AddBullets());
            readyToLoadBullets = false;
        }
        else if (currentBullets >= maxBullets && readyToLoadBullets) drone.state = DroneMovement.States.fallingIN;
    }

    IEnumerator AddBullets()
    {
        currentBullets += 5;
        yield return new WaitForSeconds(2);
        readyToLoadBullets = true;
    }
}
