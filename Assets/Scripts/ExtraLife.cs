using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : PowerUp
{
    protected override void ActivatePowerUp(Collider2D player)
    {
        PlayerHealth health = player.GetComponentInChildren<PlayerHealth>();
        if (health.healthPoints < 3) {
            health.healthPoints++;
        }
    }

    protected override void DeactivatePowerUp(Collider2D player) {}
}
