using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    

    //Happens Before Start
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }
}
