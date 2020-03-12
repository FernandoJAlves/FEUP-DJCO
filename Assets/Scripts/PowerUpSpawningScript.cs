using UnityEngine;

public class PowerUpSpawningScript : MonoBehaviour
{

    // List of power ups
    public GameObject calPowerUp;

    public float spawnRate = 6f;
    float nextSpawn = 0f;

    // Enum of valid power ups
    public enum NextPowerType {
        CAL_POWER
    }

    // Update is called once per frame
    void Update() {
        if (Time.time > nextSpawn) {
            spawnPowerUp();
        }
    }

    private void spawnPowerUp() {

        nextSpawn = Time.time + spawnRate;        
        NextPowerType nextEnemyType = getNextPowerUp();

        switch (nextEnemyType)
        {
            case NextPowerType.CAL_POWER:
                float randOffsetY = Random.Range(-1.2f, 1.2f);
                Vector3 spawnPoint = new Vector3 (7f, randOffsetY, -5f);
                Instantiate (calPowerUp, spawnPoint, Quaternion.identity);
                break;

            default:
                break;
        }

    }

    private NextPowerType getNextPowerUp() {
        
        float randValue = Random.Range(0f, 1f);
        
        // currently always spawns CAL_POWER
        if (randValue >= 0f) {
            return NextPowerType.CAL_POWER;
        }

        Debug.LogError("Enexpected return statement reached");
        return NextPowerType.CAL_POWER;
    }

    
}
