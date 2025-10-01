using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text highScore;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void Update()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        int currentScore = ScoreManager.instance.totalScore;
        score.SetText(currentScore.ToString());

        int currentHighScore = ScoreManager.instance.totalHighScore;
        highScore.SetText(currentHighScore.ToString());
    }

}
