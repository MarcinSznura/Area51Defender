using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeMovement : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    public bool isCalled = false;
    bool shouldSoundPlay = true;

    private void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 450f);
        
    }

    void Update()
    {
        if (isCalled)
        {
            MoveTowardsWaypoint();
            if (shouldSoundPlay)
            {
                GetComponent<AudioSource>().Play();
                shouldSoundPlay = false;
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
            shouldSoundPlay = true;
        }
    }

    private void MoveTowardsWaypoint()
    {
        if (transform.position != endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, 1f);
        }
        else
        {
            isCalled = false;
            transform.position = startPosition;
        }
    }

}
