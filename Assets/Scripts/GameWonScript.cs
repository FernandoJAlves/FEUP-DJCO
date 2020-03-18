using UnityEngine;
using UnityEngine.UI;

public class GameWonScript : MonoBehaviour
{
    private string scoreLabel = "SCORE: ";
    public Text scoreText;

    // Start is called before the first frame update
    private void OnEnable() {
        float score = GameStateController.instance.score;
        scoreText.text = scoreLabel + score.ToString("000");
    }

}
