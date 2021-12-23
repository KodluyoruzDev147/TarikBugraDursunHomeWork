using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public bool isGameStart;
    public bool isGameFinish;
    public bool isReset;

    [SerializeField] private LevelList levelList;

    #endregion

    #region Singleton
    public static GameManager instance;
    
    private void InitSingleton() 
    {
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }

    void Start()
    {
        LevelManager.SetLevelManager(levelList);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        }
        if (PlayerCollisionControl.instance.isFinished)
        {
            isGameFinish = true;
            isGameStart = false;
        }
        StartGame();
        FinishGame();
    }

    public void StartGame() 
    {
        if (isGameStart)
        {
            UIManager.instance.GameStarting();
        }
    }
    public void FinishGame() 
    {
        if (isGameFinish)
        {
            if (PlayerCollisionControl.instance.isFail)
            {
                UIManager.instance.GameFinishing(false);
            }
            else 
            {
                UIManager.instance.GameFinishing(true);
            }
        }
    }
    public void NextLevel() 
    {
        LevelManager.NextLevel();
        StartGame();
        Debug.Log("StartGame çalýþtý");
    }
    public void RestartGame() 
    {
        LevelManager.RestartLevel();
        StartGame();
    }

    //private void ResetGame() 
    //{
    //    isReset = true;
    //}
}
