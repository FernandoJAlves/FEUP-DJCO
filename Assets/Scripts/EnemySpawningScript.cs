using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    // List of enemies
    public GameObject electroBot;
    public GameObject mecGirl;

    public float spawnRate = 2.5f;
    float nextSpawn = 0f;

    // Enum of valid enemies
    public enum NextEnemyType {
        ELECTROBOT, MECGIRL
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
                float randOffsetY = Random.Range(-0.5f, 0.5f);
                Vector3 spawnPoint = new Vector3 (6f, 1.4f + randOffsetY, -5f);
                Instantiate (electroBot, spawnPoint, Quaternion.identity);
                break;
            }

            case NextEnemyType.MECGIRL: {
                float randOffsetY = Random.Range(-0.3f, 0.3f);
                Vector3 spawnPoint = new Vector3 (6f, -1.3f + randOffsetY, -5f);
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
