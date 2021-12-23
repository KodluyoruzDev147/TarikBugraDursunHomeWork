using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portaltype type;
}
public enum Portaltype 
{
    add5,
    remove2,
    add1,
    divide1,
    finish
};
