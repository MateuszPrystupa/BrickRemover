using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int currentScore;
    private int highScore;
    public int totalScore { get; private set; }
    public int totalHighScore { get; private set; }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        totalScore = currentScore;
    }
    public void HighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            totalHighScore = highScore;
        }
    }
    public void ResetScore()
    {
        currentScore = 0;
        totalScore = 0;
    }
}
