using UnityEngine;

public class PowerUpSpawningScript : MonoBehaviour
{

    // List of power ups
    public GameObject calPowerUp;
    public GameObject aocPowerUp;
    public GameObject lifePowerUp;

    public float spawnRate = 6f;
    float nextSpawn = 0f;

    // Enum of valid power ups
    public enum NextPowerType {
        CAL_POWER, AOC_POWER, LIFE_POWER
    }

    private float screenHeight = 0f;
    private float screenWidth = 0f;

    private void Start() {
        Vector2 topRightCorner = new Vector2(1, 1);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        screenHeight = edgeVector.y * 2;
        screenWidth = edgeVector.x * 2;
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
            case NextPowerType.CAL_POWER: {
                float randOffsetY = Random.Range(-1.2f, 1.2f);
                Vector3 spawnPoint = new Vector3 (screenWidth + 1f, randOffsetY, -5f);
                Instantiate (calPowerUp, spawnPoint, Quaternion.identity);
                break;
            }

            case NextPowerType.AOC_POWER: {
                float randOffsetY = Random.Range(-1.2f, 1.2f);
                Vector3 spawnPoint = new Vector3 (screenWidth + 1f, randOffsetY, -5f);
                Instantiate (aocPowerUp, spawnPoint, Quaternion.identity);
                break;
            }

            case NextPowerType.LIFE_POWER: {
                float randOffsetY = Random.Range(-1.2f, 1.2f);
                Vector3 spawnPoint = new Vector3 (screenWidth + 1f, randOffsetY, -5f);
                Instantiate (lifePowerUp, spawnPoint, Quaternion.identity);
                break;
            }

            default:
                break;
        }

    }

    private NextPowerType getNextPowerUp() {
        
        float randValue = Random.Range(0f, 1f);
        
        // 50% of CAL_POWER
        if (randValue <= 0.5f) {
            return NextPowerType.CAL_POWER;
        }
        // 35% of AOC_POWER
        else if (randValue <= 0.85f) {
            return NextPowerType.AOC_POWER;
        }
        // 15% of LIFE_POWER
        else if (randValue <= 1f) {
            return NextPowerType.LIFE_POWER;
        }

        Debug.LogError("Enexpected return statement reached");
        return NextPowerType.CAL_POWER;
    }

    
}
