using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    // List of enemies
    public GameObject electroBot;
    public GameObject mecGirl;

    // Vars for spawnRate
    public float spawnRate = 2.5f;
    float nextSpawn = 0f;

    // Vars for waves duration
    public float durationWave1 = 30f;
    public float durationWave2 = 30f;
    public float durationWave3 = 30f;
    public float durationBetweenRounds = 5f;

    // Enum of valid enemies
    public enum NextEnemyType {
        ELECTROBOT, MECGIRL
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
            spawnEnemy();
        }

    }

    private void spawnEnemy() {

        nextSpawn = Time.time + spawnRate;        
        NextEnemyType nextEnemyType = getNextEnemy();

        switch (nextEnemyType)
        {
            case NextEnemyType.ELECTROBOT: {
                float randOffsetY = Random.Range(-screenHeight/2 + 1.5f, screenHeight/2 - 1f);
                Vector3 spawnPoint = new Vector3 (screenWidth/2 + 1f, randOffsetY, -5f);
                Instantiate (electroBot, spawnPoint, Quaternion.identity);
                break;
            }

            case NextEnemyType.MECGIRL: {
                float randOffsetY = Random.Range(-screenHeight/2 + 1.5f, screenHeight/2 - 1f);
                Vector3 spawnPoint = new Vector3 (screenWidth/2 + 1f, randOffsetY, -5f);
                Instantiate (mecGirl, spawnPoint, Quaternion.identity);
                break;
            }

            default:
                break;
        }


    }

    private NextEnemyType getNextEnemy() {
        float randValue = Random.Range(0f, 1f);
        
        // 50% of ElectroBot
        if (randValue <= 0.5f) {
            return NextEnemyType.ELECTROBOT;
        }
        // 50% of MecGirl
        else if (randValue <= 1f) {
            return NextEnemyType.MECGIRL;
        }

        Debug.LogError("Enexpected return statement reached");
        return NextEnemyType.ELECTROBOT;
    }
}
