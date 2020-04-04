using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrike : MonoBehaviour
{
    [SerializeField] AirStrikeMovement airStrikePrefab;
    [SerializeField] AirStrikeMovement napalmPrefab;
    [SerializeField] float cooldownSkillTime = 10f;

    public int airStrikeValue;
    public int napalmValue;

    bool isReadyAirStrike = true;
    bool isReadyNapalm = true;

    private Dictionary<string, KeyCode> keys; 

    private void Start()
    {
        keys = FindObjectOfType<MainMenu>().keys;
        //airStrikeValue = FindObjectOfType<Upgrademenu>().GetbaseAirStrike();
        airStrikeValue = 1;
        napalmValue = FindObjectOfType<Upgrademenu>().GetbaseNapalm();
    }

    void Update()
    {
        ProcessSkillActivations();
    }

    private void ProcessSkillActivations()
    {
        if (Input.GetKey(keys["skill1"]))
        {
            if (isReadyAirStrike && airStrikeValue >= 1)
            {
                StartAirStrike();
                StartCoroutine(AirStrikeCooldown());
            }
        }

        if (Input.GetKey(keys["skill2"]))
        {
            if (isReadyNapalm && napalmValue >= 1)
            {
                StartNapalm();
                StartCoroutine(NapalmCooldown());
            }
        }
    }

    private void StartAirStrike()
    {
        airStrikePrefab.isCalled = true;
        Invoke("TakeEnemyHp", 2f);
    }

    private void TakeEnemyHp()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        foreach (EnemyDamage enemy in sceneEnemies)
        {
            enemy.ProcessDamageRecivedFromAirStrike1();
        }
    }

    private void StartNapalm()
    {
        napalmPrefab.isCalled = true;
        Invoke("SetAllEnemyOnFire", 2f);
    }

    private void SetAllEnemyOnFire()
    {
        var sceneEnemies = FindObjectsOfType<EnemyDamage>();

        foreach (EnemyDamage enemy in sceneEnemies)
        {
            enemy.ProcessDamageRecivedFromAirStrike2();
        }
    }

    IEnumerator AirStrikeCooldown()
    {
        isReadyAirStrike = false;
        yield return new WaitForSeconds(cooldownSkillTime);
        isReadyAirStrike = true;
    }

    IEnumerator NapalmCooldown()
    {
        isReadyNapalm = false;
        yield return new WaitForSeconds(cooldownSkillTime);
        isReadyNapalm = true;
    }
}
