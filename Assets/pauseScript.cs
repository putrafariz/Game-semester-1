using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
