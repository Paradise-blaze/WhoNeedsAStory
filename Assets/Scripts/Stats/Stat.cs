using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class represents one particular statistic (f.e. health, armor, etc)
[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    public int GetValue() { return baseValue; }
    
}
