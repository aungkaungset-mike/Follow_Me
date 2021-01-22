using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPause;
    public Text HighScore;
    public Text Score;


    private void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(false);
            
        }
        
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FollowMe");
   
       
    }
    public void Quit()
    {
        Application.Quit();

    }
}
