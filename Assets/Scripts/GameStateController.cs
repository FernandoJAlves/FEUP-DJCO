﻿using UnityEngine;
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

    public GameObject gameWonUI;

    void Awake()
    {
        instance = this;
    }

    private void Update() {
        if (gameState == GameState.GAMEWON) {
            // TODO: remove this, temporary while I have no buttons
            if (Input.GetKey("r")) {
                Invoke("RestartLevel", restartDelay);
            }
        } else if (gameState == GameState.PLAYING) {
            playTime += Time.deltaTime;
            timeSinceLastScoreSync += Time.deltaTime;

            if (playTime >= 40f) { // TODO: Adjust this
                GameWon();
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

    public void GameWon() {
        gameState = GameState.GAMEWON;
        Debug.Log("Game Won!");
        gameWonUI.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().enabled = false;
        DisableGameSpawners();
    }

    public void DisableGameSpawners() {
        GetComponent<EnemySpawningScript>().enabled = false;
        GetComponent<ObstacleSpawningScript>().enabled = false;
        GetComponent<PowerUpSpawningScript>().enabled = false;
    }

    public void Score(int points) {
        this.score += points;
    }


}
