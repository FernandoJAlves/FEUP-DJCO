using UnityEngine;

public class MecGirlProjectiles : MonoBehaviour
{
    public float timeSinceLastShot = 0f;
    public float maxTimeBetweenShots = 2f; // fire once every 2 seconds

    public GameObject mecGirlScrewPrefab;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= maxTimeBetweenShots) {
            // now the bot should fire
            timeSinceLastShot = 0f;
            // FIRE!
            Shoot();
        }
    }

    public void Shoot() {
        Debug.Log("FIRE!!!");
        Instantiate(mecGirlScrewPrefab, transform.position, Quaternion.identity);
    }
}
