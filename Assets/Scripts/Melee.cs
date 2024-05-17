using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Troop
{
    public void Start()
    {
        troopStart();
        Debug.Log(baseEntry);
    }
}
