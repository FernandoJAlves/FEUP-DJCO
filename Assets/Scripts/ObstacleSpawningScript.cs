using UnityEngine;

public class ObstacleSpawningScript : MonoBehaviour
{
    // List of obstacles
    public GameObject carObstacle;
    
    public float spawnRate = 8f;
    float nextSpawn = 0f;

    // Update is called once per frame
    void Update() {
        
        if (Time.time > nextSpawn) {
            spawnObstacle();
        }

    }

    private void spawnObstacle() {

        nextSpawn = Time.time + spawnRate;        

        // spawn a car
        float randOffsetY = Random.Range(-1.2f, 1.2f);
        Vector3 spawnPoint = new Vector3 (7f, randOffsetY, -5f);
        Instantiate (carObstacle, spawnPoint, Quaternion.identity);

    }
}
