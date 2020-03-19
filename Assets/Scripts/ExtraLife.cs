using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : PowerUp
{
    // If max Lifes exceeded
    public int score = 300;

    protected override void ActivatePowerUp(Collider2D player)
    {
        PlayerHealth health = player.GetComponentInChildren<PlayerHealth>();
        if (health.healthPoints < 3) {
            health.healthPoints++;
        }
        else {
            GameStateController.instance.Score(this.score);
        }
    }

    protected override void DeactivatePowerUp(Collider2D player) {}
}
