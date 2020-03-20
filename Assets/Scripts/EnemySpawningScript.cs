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

    // Enum of wave state
    public enum CurrentWaveType {
        WAVE1, WAVE2, WAVE3, PAUSE1, PAUSE2, PAUSE3, GAMEENDED
    }

    // Current Wave
    public CurrentWaveType currentWaveType = CurrentWaveType.WAVE1;
    private float timeInCurrentWave = 0f;

    // Enum of valid enemies
    public enum NextEnemyType {
        ELECTROBOT, MECGIRL
    }

    // Wave Number UIs
    public GameObject wave1UI;
    public GameObject wave2UI;
    public GameObject wave3UI;

    private float screenHeight = 0f;
    private float screenWidth = 0f;

    private void Start() {
        Vector2 topRightCorner = new Vector2(1, 1);
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);
        screenHeight = edgeVector.y * 2;
        screenWidth = edgeVector.x * 2;
        wave1UI.SetActive(true);
        Invoke("DisableWave1UI", 5f);
    }

    // Update is called once per frame
    void Update() {
        
        UpdateWaveState();

        if (Time.time > nextSpawn &&
            currentWaveType != CurrentWaveType.PAUSE1 &&
            currentWaveType != CurrentWaveType.PAUSE2 &&
            currentWaveType != CurrentWaveType.PAUSE3 &&
            currentWaveType != CurrentWaveType.GAMEENDED) {

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
        
        switch (currentWaveType)
        {
            case CurrentWaveType.WAVE1:
                return NextEnemyType.ELECTROBOT;

            case CurrentWaveType.WAVE2:
                return NextEnemyType.MECGIRL;
            
            case CurrentWaveType.WAVE3: {
                float randValue = Random.Range(0f, 1f);
                // 50% of ElectroBot
                if (randValue <= 0.5f) {
                    return NextEnemyType.ELECTROBOT;
                }
                // 50% of MecGirl
                else {
                    return NextEnemyType.MECGIRL;
                }
            }
            
            default:
                Debug.LogError("Enexpected default statement reached");
                return NextEnemyType.ELECTROBOT;
        }
    }

    private void UpdateWaveState () {

        timeInCurrentWave += Time.deltaTime;

        switch (currentWaveType) {
            case CurrentWaveType.WAVE1: 
                if (timeInCurrentWave > durationWave1) {
                    currentWaveType = CurrentWaveType.PAUSE1;
                    timeInCurrentWave = 0f;
                }
                break;
            case CurrentWaveType.WAVE2: 
                if (timeInCurrentWave > durationWave2) {
                    currentWaveType = CurrentWaveType.PAUSE2;
                    timeInCurrentWave = 0f;
                }
                break;
            case CurrentWaveType.WAVE3: 
                if (timeInCurrentWave > durationWave3) {
                    currentWaveType = CurrentWaveType.PAUSE3;
                    timeInCurrentWave = 0f;
                    GameStateController.instance.DisableObstacleAndPowerUpsSpawners();
                }
                break;
            case CurrentWaveType.PAUSE1: 
                if (timeInCurrentWave > durationBetweenRounds) {
                    currentWaveType = CurrentWaveType.WAVE2;
                    wave2UI.SetActive(true);
                    Invoke("DisableWave2UI", 5f);
                    timeInCurrentWave = 0f;
                }
                break;
            case CurrentWaveType.PAUSE2: 
                if (timeInCurrentWave > durationBetweenRounds) {
                    currentWaveType = CurrentWaveType.WAVE3;
                    wave3UI.SetActive(true);
                    Invoke("DisableWave3UI", 5f);
                    timeInCurrentWave = 0f;
                }
                break;
            case CurrentWaveType.PAUSE3:
                if (timeInCurrentWave > durationBetweenRounds) {
                    GameStateController.instance.GameWon();
                    currentWaveType = CurrentWaveType.GAMEENDED;
                    timeInCurrentWave = 0f;
                }
                break;

            default:
                break;
        }
    }

    public void DisableWave1UI () {
        wave1UI.SetActive(false);
    }

    public void DisableWave2UI () {
        wave2UI.SetActive(false);
    }

    public void DisableWave3UI () {
        wave3UI.SetActive(false);
    }

}
