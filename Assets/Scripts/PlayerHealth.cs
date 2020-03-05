using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // The current health the player has.
    public int healthPoints;

    //The reference to the player
    
    public GameObject player;

    // Update is called once per frame
    void Update()
    {

    }

    void TakeDamage() {
        this.healthPoints--;

        if (this.healthPoints <= 0) {

        }
    }
}
