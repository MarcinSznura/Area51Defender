using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] AudioClip spawnEnemySFX1;
    [SerializeField] AudioClip spawnEnemySFX2;
    [SerializeField] AudioClip spawnEnemySFX3;
    [SerializeField] AudioClip spawnEnemySFX4;
    [SerializeField] AudioClip spawnEnemySFX5;

    private WaveMenu waveInfo;

    private bool areYouDoneSpawning = false;
    private float secondBetweenSpawns = 5f;
    public Vector3[] spawningPositions;

    float soundVolume;

    void Start()
    {
        waveInfo = FindObjectOfType<WaveMenu>();
        soundVolume = FindObjectOfType<MainMenu>().soundsValue;

        SetSpawningPositions();

        StartCoroutine(SpawnEnemy(1));

    }

    private void SetSpawningPositions()
    {
        spawningPositions[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        spawningPositions[1] = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
        spawningPositions[2] = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
        spawningPositions[3] = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20);
        spawningPositions[4] = new Vector3(transform.position.x, transform.position.y, transform.position.z - 20);
        spawningPositions[5] = new Vector3(transform.position.x, transform.position.y, transform.position.z + 30);
        spawningPositions[6] = new Vector3(transform.position.x, transform.position.y, transform.position.z - 30);

        spawningPositions[7] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
        spawningPositions[8] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + 10);
        spawningPositions[9] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z - 10);
        spawningPositions[10] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + 20);
        spawningPositions[11] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z - 20);
        spawningPositions[12] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z + 30);
        spawningPositions[13] = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z - 30);

        spawningPositions[14] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);
        spawningPositions[15] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z + 10);
        spawningPositions[16] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z - 10);
        spawningPositions[17] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z + 20);
        spawningPositions[18] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z - 20);
        spawningPositions[19] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z + 30);
        spawningPositions[19] = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z - 30);
    }

    void Update()
    {
        if (areYouDoneSpawning)
        {
            if (FindObjectOfType<EnemyMovement>() == null)
            {
                if (!FindObjectOfType<TimeMaster>().isBattleOver())
                {
                    FindObjectOfType<TimeMaster>().EndOfWave();
                }
            }
        }
    }



    [ContextMenu("TestSpawn")] //TODO: delete this
    public void TestSpawn()
    {
        StartCoroutine(SpawnEnemy(FindObjectOfType<TimeMaster>().wave));
    }

    public void SpawnAgain()
    {
        if (areYouDoneSpawning)
        {
            areYouDoneSpawning = false;
            StartCoroutine(SpawnEnemy(FindObjectOfType<TimeMaster>().wave));
        }
    }

    IEnumerator SpawnEnemy(int wave)
    {

        int spawn = waveInfo.waves[wave - 1].spawn_number.Length;

        for (int i = 0; i < spawn; i++)
        {
            for (int j = 0; j < waveInfo.waves[wave - 1].spawn_number[i]; j++)
            {
                var newEnemy = Instantiate(enemyPrefab, spawningPositions[j], Quaternion.identity);
                newEnemy.transform.parent = enemyParent.transform;
            }

            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX1, soundVolume * .4f);
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX2, soundVolume * .4f);
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX3, soundVolume * .4f);
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX4, soundVolume * .4f);
            GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX5, soundVolume * .4f);

            yield return new WaitForSeconds(waveInfo.waves[wave - 1].time_to_spawn[i]);
        }
        areYouDoneSpawning = true;
    }

}
