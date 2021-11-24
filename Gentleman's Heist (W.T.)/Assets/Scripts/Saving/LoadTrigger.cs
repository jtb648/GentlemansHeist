using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    void Start()
    {
        if (SaveMaster.needsLoad)
        {
            SaveMaster.LoadAll("Paul_Blart");
        }
    }
    
}
