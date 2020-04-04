using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public float soundsValue = .5f;
    public float musicValue = .5f;
    public int language = 0; // 0-eng; 1-pl

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();


    private void Awake()
    {
        MainMenu[] me = FindObjectsOfType<MainMenu>();
        if (me.Length != 1) Destroy(gameObject);
    }

    private void Start()
    {
        keys.Add("up", KeyCode.W);
        keys.Add("down", KeyCode.S);
        keys.Add("left", KeyCode.A);
        keys.Add("right", KeyCode.D);
        keys.Add("fire", KeyCode.Space);
        keys.Add("skill1", KeyCode.Alpha1);
        keys.Add("skill2", KeyCode.Alpha2);
        soundsValue = .5f;
        musicValue = .5f;

        Cursor.visible = true;
        DontDestroyOnLoad(gameObject);
    }



    

}
