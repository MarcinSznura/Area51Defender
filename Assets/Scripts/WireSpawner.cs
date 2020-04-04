using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSpawner : MonoBehaviour
{

    [SerializeField] GameObject wirePrefab;
 
    public void SpawningWires(int wire)
    {
        switch (wire)
        {
            case 0:
                break;

            case 1:
                var wire1= Instantiate(wirePrefab, transform.position, Quaternion.identity);
                wire1.transform.parent = gameObject.transform;
                break;

            case 2:
                var wire2 = Instantiate(wirePrefab, new Vector3(transform.position.x - 8, transform.position.y, transform.position.z), Quaternion.identity);
                wire2.transform.parent = gameObject.transform;
                break;

            case 3:
                var wire3 = Instantiate(wirePrefab, new Vector3(transform.position.x - 16, transform.position.y, transform.position.z), Quaternion.identity);
                wire3.transform.parent = gameObject.transform;
                break;

            case 4:
                var wire4 = Instantiate(wirePrefab, new Vector3(transform.position.x - 24, transform.position.y, transform.position.z), Quaternion.identity);
                wire4.transform.parent = gameObject.transform;
                break;

            case 5:
                var wire5 = Instantiate(wirePrefab, new Vector3(transform.position.x - 32, transform.position.y, transform.position.z), Quaternion.identity);
                wire5.transform.parent = gameObject.transform;
                break;

        }
    }
}
