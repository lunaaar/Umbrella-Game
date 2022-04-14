using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class SaveData
{
    
    public int level; //current level
    //public int death; //total number of deaths?
    public string date; // last time the game was saved

    public SaveData()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        date = System.DateTime.UtcNow.ToLocalTime().ToString("m/d/yy  hh:mm");
    }

    public SaveData(int level)
    {
        this.level = level;
        date = System.DateTime.UtcNow.ToLocalTime().ToString("m/d/yy  hh:mm");
    }
}
