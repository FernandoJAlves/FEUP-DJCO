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
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        // Shooting Logic
        Instantiate(boltPrefab, FirePoint.position, FirePoint.rotation);
    }
}
