using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI scoreText;

   int score = 0;

   public void AddScore (int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;
    }
}
