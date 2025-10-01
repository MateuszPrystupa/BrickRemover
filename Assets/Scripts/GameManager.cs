using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private Canvas blackCanva;
    [SerializeField] private Canvas blackCanvaText;
    [SerializeField] private GameObject[] gameObjectLevel;
    [SerializeField] private GameObject[] gameObjectPrefabBrickLevel01;
    [SerializeField] private GameObject[] gameObjectPrefabBrickLevel02;
    [SerializeField] private GameObject[] gameObjectPrefabBrickLevel03;
    public bool isLevelDone1 = true;
    public bool isLevelDone2 = false;
    public bool isLevelDone3 = false;
    private int brickCountLevel1;
    private int brickCountLevel2;
    private int brickCountLevel3;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        LevelOff();
        blackCanva.enabled = true;
        blackCanvaText.enabled = false;
    }

    private void Start()
    {
        brickCountLevel1 = gameObjectPrefabBrickLevel01.Length;
        brickCountLevel2 = gameObjectPrefabBrickLevel02.Length;
        brickCountLevel3 = gameObjectPrefabBrickLevel03.Length;
        isLevelDone1 = true;
    }

    private void LevelOff()
    {
        for (int i = 1; i < gameObjectLevel.Length; i++)
        {
            gameObjectLevel[i].SetActive(false);
        }
    }


    public void BrickCountLevel1()
    {
        brickCountLevel1--;

        if (brickCountLevel1 <= 0 && gameObjectLevel[0] == true)
        {
            gameObjectLevel[0].SetActive(false);
            gameObjectLevel[1].SetActive(true);
            isLevelDone1 = true;
            isLevelDone2 = true;
        }
    }
    public void BrickCountLevel2()
    {
        brickCountLevel2--;
        if (brickCountLevel2 <= 0 && gameObjectLevel[1] == true)
        {
            gameObjectLevel[1].SetActive(false);
            gameObjectLevel[2].SetActive(true);
            isLevelDone2 = true;
            isLevelDone3 = true;
        }
    }

    public void BrickCountLevel3()
    {
        brickCountLevel3--;
        if (brickCountLevel3 <= 0 && gameObjectLevel[2] == true)
        {
            gameObjectLevel[2].SetActive(false);
            isLevelDone3 = true;
            gameObjectLevel[3].SetActive(true);
        }
    }
}