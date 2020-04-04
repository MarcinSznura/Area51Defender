using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{

    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    public bool areDronesActive = false;
    bool waitToShotAgain = false;

    public enum States { reloading,fallingIN, atacking, fallingOUT };
    public States state = States.reloading;

    DroneTargeting drone;

    private void Start()
    {
        drone = gameObject.GetComponent<DroneTargeting>();
    }
  
    // Update is called once per frame
    void Update()
    {
        if (areDronesActive && Time.timeScale != 0)
        {
            switch (state)
            {
                case States.reloading:
                    drone.Reloading();
                    break;

                case States.fallingIN:
                    MovingToCombatZone();
                    break;

                case States.atacking:
                    if (!waitToShotAgain)
                    {
                        drone.Shooting();
                        StartCoroutine(WaitToShotAgain());
                    }
                    break;

                case States.fallingOUT:
                    MovingToRelodingZone();
                    break;
            }
        }
    }

    private void MovingToRelodingZone()
    {
        if (transform.position != startPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, 0.5f);
        }
        else state = States.reloading;
    }

    private void MovingToCombatZone()
    {
        if (transform.position != endPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, 0.5f);
        }
        else state = States.atacking;
    }
    
    IEnumerator WaitToShotAgain()
    {
        waitToShotAgain = true;
        yield return new WaitForSeconds(1);
        waitToShotAgain = false;
    }

}
