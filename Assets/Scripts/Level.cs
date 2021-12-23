using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void DestroyLevel() 
    {
        Destroy(this.gameObject);
    }
}
