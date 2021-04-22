using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{

    public CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

}
