using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject nextPanel;
    [SerializeField] private GameObject failPanel;
    #endregion

    #region Singleton
    public static UIManager instance;

    private void InitSingleton() 
    {
        if (instance==null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this);
        }
    }

    private void Awake()
    {
        InitSingleton();
    }
    #endregion

    public void GameStarting() 
    {
        startPanel.SetActive(false);
        nextPanel.SetActive(false);
        failPanel.SetActive(false);
    }
    public void GameFinishing(bool win) 
    {
        if (win)
        {
            nextPanel.SetActive(true);
        }
        else 
        {
            failPanel.SetActive(true);
        }
    }
}
