using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void load1()
    {
        SaveData data = SaveSystem.load1();
        SceneManager.LoadScene(data.level);

    }

    public void load2()
    {
        SaveData data = SaveSystem.load2();
        SceneManager.LoadScene(data.level);
    }

    public void load3()
    {
        SaveData data = SaveSystem.load3();
        SceneManager.LoadScene(data.level);

    }
}
