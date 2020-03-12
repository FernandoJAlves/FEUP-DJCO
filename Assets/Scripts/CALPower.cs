using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CALPower : PowerUp
{
    public float speedFactor = 1.2f;

    protected override void ActivatePowerUp(Collider2D player) {
        player.GetComponent<BoltGun>().multiplySpeed(speedFactor);
    }

    protected override void DeactivatePowerUp(Collider2D player) {
        player.GetComponent<BoltGun>().divideSpeed(speedFactor);
    }
}
