using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMaster : MonoBehaviour
{
    public enum GameState { battle, summary, upgrade };

    public int wave = 1;
    [SerializeField] bool timeStopeed = false;
    public GameState gameState = GameState.battle;

    [SerializeField] Canvas upgradeCanvas;

    IEnumerator StopTime()
    {
        timeStopeed = true;
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<Tower>().BarellSound();
        Time.timeScale = 0;
    }

    private void RestoreTime()
    {
        timeStopeed = false;
        Time.timeScale = 1;
    }

    public void EndOfWave()
    {
        gameState = GameState.upgrade;
        FindObjectOfType<Upgrademenu>().IncreasePlayerExpierience(FindObjectOfType<WaveMenu>().waves[wave-1].waveReward);
        upgradeCanvas.enabled = true;
        FindObjectOfType<UpgradeMenuActivator>().ActivateUpgradeMenu(true);
        StartCoroutine(StopTime());
    }

    public bool isBattleOver()
    {
        if (gameState != GameState.battle) return true;
        else return false;
    }

    public bool TimeStopeed()
    {
        return timeStopeed;
    }

    public void LoadNextWave()
    {
        if (timeStopeed)
        {
            wave++;
            upgradeCanvas.enabled = false;
            foreach (Canvas i in upgradeCanvas.gameObject.GetComponentsInChildren<Canvas>())
            {
                i.enabled = false;
            }

            FindObjectOfType<UpgradeMenuActivator>().ActivateUpgradeMenu(false);
            gameState = GameState.battle;
            FindObjectOfType<GameGUI>().RefreshUI();
            RestoreTime();
            FindObjectOfType<EnemySpawner>().SpawnAgain();
        }
    }

    public void CloseUpgradeScreen()
    {
        if (timeStopeed)
        {
            upgradeCanvas.enabled = false;
        }
    }

    public void OpenUpgradeScreen()
    {
        if (timeStopeed)
        {
            upgradeCanvas.enabled = true;
        }
    }

}
