using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level List")]
public class LevelList : ScriptableObject
{
    public List<Level> Levels;
}

