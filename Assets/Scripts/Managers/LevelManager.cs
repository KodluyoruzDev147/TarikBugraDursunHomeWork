using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelList levelList;
    private static Level level;

    private static int levelIndex;

    public static void SetLevelManager(LevelList list)
    {
        levelList = list;
        levelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        LoadLevel();
    }
    public static void RestartLevel()
    {
        level.DestroyLevel();

        LoadLevel();
    }
    public static void LoadLevel()
    {
        level = GameObject.Instantiate(levelList.Levels[levelIndex % levelList.Levels.Count]);
    }
    public static void NextLevel()
    {
        level.DestroyLevel();
        levelIndex++;
        PlayerPrefs.SetInt("LevelIndex", levelIndex);
        LoadLevel();
    }

    public static Level GetCurrentLevel()
    {
        return level;
    }
    public static int GetCurrentLevelIndex()
    {
        return levelIndex;
    }
    public static int GetCurrentLevelNumber()
    {
        return levelIndex + 1;
    }
}
