using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpgradeMenuScript : MonoBehaviour
{
    public void ContinueNextLevel(){
        SceneManager.LoadScene("SampleScene");
    }
}
