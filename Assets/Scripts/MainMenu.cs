using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   

    //Start method that will update the text of load save
    void Start()
    {
       

    }

    //Runs on play button click
    public void PlayGame()
    {
        //main menu is 0 in build index, level 1 is 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Quit game - This is not visible in unity editor so there is a debug message
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadGame()
    {
        SaveData data = SaveSystem.load1();
        SceneManager.LoadScene(data.level);
    }
}
