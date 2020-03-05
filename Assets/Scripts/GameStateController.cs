using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public enum GameState {
        PLAYING, PAUSED, GAMEOVER
    }

    public GameState gameState = GameState.PLAYING;
    public float restartDelay = 1.5f;

    public void RestartLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void GameOver () {

        if (gameState == GameState.PLAYING) {
            gameState = GameState.GAMEOVER;
            Debug.Log("Game Over!");
            Invoke("RestartLevel", restartDelay);
        }
    }


}
