using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    [SerializeField] ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // DestroyAfterTime(1);
    }

    void DestroyAfterTime(float time)
    {
        Destroy(gameObject, time);
    }

}
