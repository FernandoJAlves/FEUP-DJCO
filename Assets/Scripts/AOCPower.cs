using UnityEngine;

public class AOCPower : PowerUp
{
    public float shootingAngle = 45f;

    protected override void ActivatePowerUp(Collider2D player)
    {
        BoltGun gunScript = player.GetComponent<BoltGun>();

        if (gunScript.getAngle() >= 180) Destroy(gameObject);

        gunScript.increaseAngle(shootingAngle);
    }

    protected override void DeactivatePowerUp(Collider2D player)
    {
        player.GetComponent<BoltGun>().decreaseAngle(shootingAngle);
    }
}
