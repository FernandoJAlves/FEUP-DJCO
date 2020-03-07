using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public GameObject playerHealth;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Player collider with " + hitInfo.name);
        playerHealth.GetComponent<PlayerHealth>().TakeDamage();
    }
}
