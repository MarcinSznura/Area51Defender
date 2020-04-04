using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelDeactivator : MonoBehaviour
{
    [SerializeField] Canvas Parent;
    [SerializeField] Canvas Child;

    void Update()
    {
        if (!Parent.isActiveAndEnabled)
        {
            Child.enabled = false; 
        }
    }
}
