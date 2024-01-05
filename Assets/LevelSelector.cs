using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{   
    //store level data
    public int level;
    public static int currentUnlockedLevel = 1; //currentUnlockedLevel : meant level 1 until whatever the value is unlocked
    
    //ui things
    public Color lockedColor = new Color(0, 0, 0, 0); 
    public Color levelSelectButtonUnlockedColor = new Color(0, 0, 0, 255);
    public TMPro.TextMeshProUGUI levelNumber;
    public Button button;

    void Start()
    {   
        //set the text on the button to the current level
        levelNumber.text = level.ToString();

        //Check if the level is smaller/same as current unlocked level
        //If smaller/same, then the current level is not locked
        //If bigger, indicates that the current level is locked
        if (level > currentUnlockedLevel)
        {   
            //set the color property on the Image component to lockedcolor
            button.GetComponent<Image>().color = lockedColor;
        }
    }

    //changeScene function, called when the user click the button
    public void ChangeScene()
    {   
        //Check if the level user clicked is smaller/same as current unlocked level
        if (level <= currentUnlockedLevel) 
        {   
            //If cuurent level is unlocked

            //load scene with the name "Level <value of the level variable>"
            //Which meant that every level scene has to follow the same naming structure = Level 1, Level 2, etc
            SceneManager.LoadScene("Level " + level.ToString());
        } else
        {   //current level is locked, send message to the console
            Debug.Log("The level you've selected (" + level + ") is not unlocked yet. Current unlocked level : " + currentUnlockedLevel);
        }
    }
}
