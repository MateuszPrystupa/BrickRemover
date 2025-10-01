using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject ball;
    [SerializeField] private Canvas myCanva;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(ball);
        ScoreManager.instance.HighScore();
        textController.isGamePause = true;
        myCanva.enabled = true;
        Time.timeScale = 0f;
        ScoreManager.instance.ResetScore();
    }
}
