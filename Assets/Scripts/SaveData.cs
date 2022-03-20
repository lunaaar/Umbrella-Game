using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SaveData
{
    
    public int level; //current level
    public int death; //total number of deaths?
    public int time; // last time the game was saved

    public SaveData()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        //time=System.DateTime.Now
    }
}
