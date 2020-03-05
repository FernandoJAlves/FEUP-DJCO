using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    // The current health the player has.
    public int healthPoints = 3;

    //The reference to the player
    
    public GameObject player;

    public void TakeDamage() {
        Debug.Log("Took Damage");

        this.healthPoints--;

        if (this.healthPoints <= 0) {
            GameStateController.instance.GameOver();
        }
    }
}
