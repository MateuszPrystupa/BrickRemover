using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
public class brick : MonoBehaviour
{
    [SerializeField] private AudioClip soundBrick;
    public GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySound(soundBrick, transform, 1f);
        if (gameObject.tag == "brick_orange")
        {
            ScoreManager.instance.AddScore(50);
        }
        else if (gameObject.tag == "brick_yellow")
        {
            ScoreManager.instance.AddScore(60);
        }
        else if (gameObject.tag == "brick_blue")
        {
            ScoreManager.instance.AddScore(70);
        }
        else if (gameObject.tag == "brick_aqua")
        {
            ScoreManager.instance.AddScore(80);
        }
        else if (gameObject.tag == "brick_deep_blue")
        {
            ScoreManager.instance.AddScore(100);
        }
        
        if (gameManager.isLevelDone1)
        {
            GameManager.instance.BrickCountLevel1();
        }
        else if (gameManager.isLevelDone2)
        {
            GameManager.instance.BrickCountLevel2();
        }
        else if (gameManager.isLevelDone3)
        {
            GameManager.instance.BrickCountLevel3();
        }

    }

    void OnCollisionExit2D(Collision2D collisionExit)
    {
        Destroy(gameObject);
    }

}
