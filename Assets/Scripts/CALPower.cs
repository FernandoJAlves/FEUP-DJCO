using UnityEngine;

public class CALPower : PowerUp
{
    public float speedFactor = 1.2f;
    public float movementSpeed = 1f;

    protected override void ActivatePowerUp(Collider2D player) {
        player.GetComponent<BoltGun>().multiplySpeed(speedFactor);
    }

    protected override void DeactivatePowerUp(Collider2D player) {
        player.GetComponent<BoltGun>().divideSpeed(speedFactor);
    }

    private void Update() {
        transform.position += new Vector3(-1, 0, 0) * movementSpeed * Time.deltaTime;
    }
}
