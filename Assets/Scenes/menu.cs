using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Sprite[] spriteMute;// 0 = on 1 = off
    public Button buttonMute;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void BackToLevelSelection()
    {
        // Implementasi metode
    }

// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToLevelSelection();
        }
    }


    public void ButtonInGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonMute()
    {
        SoundManager.Instance.MuteSound();

        if (SoundManager.Instance.music.mute == true)
        {
            buttonMute.image.sprite = spriteMute[1];
        }
        else
        {
            buttonMute.image.sprite = spriteMute[0];   
        }
    }
}
