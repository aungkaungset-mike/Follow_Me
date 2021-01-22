using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseP;
    private bool isPause;


    public void pauseG()
    {
        if (isPause)
        {
            pauseP.SetActive(false);
            Time.timeScale = 1;
            isPause = false;
        }
        else
        {
            pauseP.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
        }
    }
}
