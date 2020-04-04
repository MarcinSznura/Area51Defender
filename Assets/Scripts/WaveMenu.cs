using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMenu : MonoBehaviour
{
    public WaveDetails[] waves;

}

[System.Serializable]
public class WaveDetails
{
    public int wave;
    public int[] spawn_number;
    [Range(0f,5f)] public float[] time_to_spawn;
    public int waveReward;
}
