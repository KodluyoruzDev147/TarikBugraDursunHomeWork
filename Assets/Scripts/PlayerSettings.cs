using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerSettingsSO")]
public class PlayerSettings : ScriptableObject
{
    public float forwardSpeed;
    public float swerweSpeed;
    public float minXPos;
    public float maxXPos;
}
