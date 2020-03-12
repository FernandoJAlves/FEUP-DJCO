using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    // List of enemies
    public GameObject electroBot;

    public float spawnRate = 4f;
    float nextSpawn = 0f;

    // Enum of valid enemies
    public enum NextEnemyType {
        ELECTROBOT
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
            case NextEnemyType.ELECTROBOT:
                float randOffsetY = Random.Range(-0.5f, 0.5f);
                Vector3 spawnPoint = new Vector3 (6f, 1.4f + randOffsetY, -5f);
                Instantiate (electroBot, spawnPoint, Quaternion.identity);
                break;

            default:
                break;
        }


    }

    private NextEnemyType getNextEnemy() {
        float randValue = Random.Range(0f, 1f);
        
        if (randValue >= 0f) {
            return NextEnemyType.ELECTROBOT;
        }

        Debug.LogError("Enexpected return statement reached");
        return NextEnemyType.ELECTROBOT;
    }
}
