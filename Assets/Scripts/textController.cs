using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class textController : MonoBehaviour
{
    [SerializeField] private Canvas myCanva;
    public static bool isGamePause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void ClickButton()
    {
        SceneManager.LoadScene("SampleScene");
        myCanva.enabled = false;
        Time.timeScale = 1f;
        isGamePause = false;
        ScoreManager.instance.ResetScore();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    void Resume()
    {
        myCanva.enabled = false;
        Time.timeScale = 1f;
        isGamePause = false;
    }
    public void Pause()
    {
        myCanva.enabled = true;
        Time.timeScale = 0f;
        isGamePause = true;
        Debug.Log("Jestem w trybie pauzy");
    }
}
