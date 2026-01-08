using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI scoreText;

   int score = 0;

   void Awake()
   {
        if (!scoreText)
        {
            Debug.LogError("ScoreText not assigned", this);
        }
   }

    public void AddScore (int addScore)
    {
        score += addScore;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}
