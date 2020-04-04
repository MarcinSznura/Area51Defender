using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class KeyBindings : MonoBehaviour
{
    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI up, down, left, right, fire, skill1, skill2;

    private GameObject currentKey;

    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(0, 255, 0, 255);

    private void Start()
    {
        keys.Add("up", KeyCode.W);
        keys.Add("down", KeyCode.S);
        keys.Add("left", KeyCode.A);
        keys.Add("right", KeyCode.D);
        keys.Add("fire", KeyCode.Space);
        keys.Add("skill1", KeyCode.Alpha1);
        keys.Add("skill2", KeyCode.Alpha2);

        up.text = keys["up"].ToString().ToUpper();
        down.text = keys["down"].ToString().ToUpper();
        left.text = keys["left"].ToString().ToUpper();
        right.text = keys["right"].ToString().ToUpper();
        fire.text = keys["fire"].ToString().ToUpper();
        skill1.text = keys["skill1"].ToString().ToUpper();
        skill2.text = keys["skill2"].ToString().ToUpper();
    }

    public void BackToSettings()
    {
        FindObjectOfType<MainMenu>().keys = keys;
        SceneManager.LoadScene(1);
    }

    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString().ToUpper();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    private void Update()
    {
        Debug.Log(keys["up"].ToString()+ keys["down"].ToString()+ keys["right"].ToString()+ keys["left"].ToString());
    }

}
