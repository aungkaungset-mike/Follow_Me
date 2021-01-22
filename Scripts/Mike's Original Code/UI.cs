using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
   
    public void PlayGame()
    {
        SceneManager.LoadScene("FollowMe");

    }
    public void QuitGame()
    {
        Debug.Log("q");
        Application.Quit();
    }
}
