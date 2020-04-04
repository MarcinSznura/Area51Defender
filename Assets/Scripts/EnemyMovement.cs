using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPerFrame = 0.01f;
    //[SerializeField] ParticleSystem explodeFX;

    GameObject Area51Base;

    void Start()
    {
        Area51Base = GameObject.FindGameObjectWithTag("Finish");
        StartCoroutine(FollowPath(Area51Base.transform.position));
    }


    IEnumerator FollowPath(Vector3 playerPosition)
    {
        if (transform.position != playerPosition)
        {
            yield return StartCoroutine(MoveTowardsWaypoint(playerPosition)); // wait until enemy moves to next waypoint
        }
        SelfDestruct();
        FindObjectOfType<PlayerHealth>().BaseReached();




    }

    private IEnumerator MoveTowardsWaypoint(Vector3 playerPosition)
    {
        Vector3 fixedWaypointPos = new Vector3(playerPosition.x, playerPosition.y -3f, playerPosition.z);

        while (transform.position != fixedWaypointPos)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position,fixedWaypointPos,movementPerFrame);
            transform.position = pos;
            transform.LookAt(playerPosition);
            yield return null; 
        }
    }

    private void SelfDestruct()
    {
        //Instantiate(explodeFX, new Vector3(transform.position.x-5, transform.position.y + 5, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("bump"))
        {
            movementPerFrame = 0.05f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("bump"))
        {
            movementPerFrame = 0.2f;
        }
    }

}
