using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public static ExplosionSpawner instance;
    public GameObject explosion;

    void Awake()
    {
        instance = this;
    }

    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quaternion.identity);
    }
}
