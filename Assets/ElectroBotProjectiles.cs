using UnityEngine;

public class ElectroBotProjectiles : MonoBehaviour
{

    public float timeSinceLastShot = 0f;
    public float maxTimeBetweenShots = 2f; // fire once every 2 seconds

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= maxTimeBetweenShots) {
            // now the bot should fire
            timeSinceLastShot = 0f;
            // FIRE!
            Debug.Log("FIRE!!!");
        }
    }
}
