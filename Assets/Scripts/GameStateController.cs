using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{

    public static GameStateController instance;

    public enum GameState
    {
        PLAYING, PAUSED, GAMEOVER, GAMEWON
    }

    public GameState gameState = GameState.PLAYING;
    public float restartDelay = 1.5f;
    public float playTime = 0f;
    public float timeMultiplier = 10f;
    private float timeSinceLastScoreSync = 0f;

    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    private void Update() {
        if (gameState == GameState.PLAYING) {
            playTime += Time.deltaTime;
            timeSinceLastScoreSync += Time.deltaTime;

            if (playTime >= 40f) { // TODO: Adjust this
                gameState = GameState.GAMEWON;
                Debug.Log("Game Won!");
                Invoke("RestartLevel", restartDelay);
            }

            if (timeSinceLastScoreSync >= 0.2f) {
                score += Mathf.CeilToInt(timeSinceLastScoreSync * timeMultiplier); // TODO: Review this with Juan
                timeSinceLastScoreSync = 0f;
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GameOver()
    {

        if (gameState == GameState.PLAYING)
        {
            gameState = GameState.GAMEOVER;
            Debug.Log("Game Over!");
            Invoke("RestartLevel", restartDelay);
        }
    }

    public void Score(int points) {
        this.score += points;
    }


}
