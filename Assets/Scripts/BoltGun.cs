using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltGun : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject boltPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bolt = ObjectPooler.sharedInstance.GetPooledObject();
        if (bolt != null)
        {
            bolt.transform.position = FirePoint.position;
            bolt.transform.rotation = FirePoint.rotation;
            bolt.SetActive(true);
        }
    }
}
