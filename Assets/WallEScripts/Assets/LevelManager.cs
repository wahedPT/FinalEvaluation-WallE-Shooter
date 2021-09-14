using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float autoLoadLevelTimer;
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
        {
            Invoke("LoadNextLevel", autoLoadLevelTimer);
        }
      
    }
        //[System.Obsolete]
    public void LoadLevel(string anme)
    {
        SceneManager.LoadScene(name);
    }
    public void PreviousLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        SceneManager.LoadScene(6);
    }

   // [System.Obsolete]

    public void LoadNextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void PreviousNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(3);
    }
    public void Retry()
    {
        SceneManager.LoadScene(2);
    }
    public void menu()
    {
        SceneManager.LoadScene(1);
    }
}
