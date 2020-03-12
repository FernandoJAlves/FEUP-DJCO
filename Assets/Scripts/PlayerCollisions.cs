using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public GameObject playerHealth;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        string tag = hitInfo.tag;
        Debug.Log("Player collider with " + hitInfo.name);

        if (tag == "Power-UP") {
            return;
        }

        playerHealth.GetComponent<PlayerHealth>().TakeDamage();
    }
}
