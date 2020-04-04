using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HintPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Canvas hint;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hint.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hint.enabled = false;
    }

    public void hintsActive(bool flip)
    {
        if (flip == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
