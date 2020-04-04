using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineSpawner : MonoBehaviour
{
    [SerializeField] GameObject marinePrefab;

    void Start()
    {
        SpawningMarine();
    }

    public void SpawningMarine()
    {
        RemovingOldMarine();
        int marineNumber = FindObjectOfType<Upgrademenu>().GetbaseSquadSize();

        switch (marineNumber)
        {
            case 0:
                break;

            case 1:
                var soldier11 = Instantiate(marinePrefab, transform.position, Quaternion.identity);
                soldier11.transform.parent = gameObject.transform;
                break;

            case 2:
                var soldier21 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity);
                soldier21.transform.parent = gameObject.transform;
                var soldier22 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
                soldier22.transform.parent = gameObject.transform;
                break;

            case 3:
                var soldier31 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), Quaternion.identity);
                soldier31.transform.parent = gameObject.transform;
                var soldier32 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                soldier32.transform.parent = gameObject.transform;
                var soldier33 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 10), Quaternion.identity);
                soldier33.transform.parent = gameObject.transform;
                break;

            case 4:
                var soldier41 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 15), Quaternion.identity);
                soldier41.transform.parent = gameObject.transform;
                var soldier42 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 5), Quaternion.identity);
                soldier42.transform.parent = gameObject.transform;
                var soldier43 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 5), Quaternion.identity);
                soldier43.transform.parent = gameObject.transform;
                var soldier44 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 15), Quaternion.identity);
                soldier44.transform.parent = gameObject.transform;
                break;

            case 5:
                var soldier51 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), Quaternion.identity);
                soldier51.transform.parent = gameObject.transform;
                var soldier52 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10), Quaternion.identity);
                soldier52.transform.parent = gameObject.transform;
                var soldier53 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0), Quaternion.identity);
                soldier53.transform.parent = gameObject.transform;
                var soldier54 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 10), Quaternion.identity);
                soldier54.transform.parent = gameObject.transform;
                var soldier55 = Instantiate(marinePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z - 20), Quaternion.identity);
                soldier55.transform.parent = gameObject.transform;
                break;

        }
    }

    public void RemovingOldMarine()
    {
        MarineTargeting[] marines = FindObjectsOfType<MarineTargeting>();
        if (marines != null)
        foreach (MarineTargeting marine in marines)
        {
            Destroy(marine.gameObject);
        }
    }

}
