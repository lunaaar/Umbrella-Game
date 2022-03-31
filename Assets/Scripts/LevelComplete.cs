using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    
   private void Start()
    {
        
    }

  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Game Player"){
            finishLevel();
        }
    }

private void finishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
