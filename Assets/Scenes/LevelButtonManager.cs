using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    public Color lockedColor;
    public Color unlockedColor;
    public int currentUnlockedLevel = 1;
    public int totalLevel = 5;
    public LevelButton[] levelButtons;

    void Start()
    {
        InitLevelButtons();
    }


    [ContextMenu("add level")]
    void unlockNextLevel()
    {
        currentUnlockedLevel++;
    }

    void InitLevelButtons()
    { 
        foreach (LevelButton button in levelButtons)
        {
            button.Init();
            UpdateButtonColor(button);
        }
    }

    public void UpdateButtonColor(LevelButton button)
    {
        for (int i = 1; i <= totalLevel; i++)
        {
            if (i <= currentUnlockedLevel)
            {
                button.button.interactable = true;
                button.buttonImage.color = unlockedColor;
            }
            else if (i > currentUnlockedLevel)
            {
                button.button.interactable = false;
                button.buttonImage.color = lockedColor;
            }
        }
    }

    // Metode ini dapat dipanggil untuk mengganti warna tombol sesuai dengan kebutuhan lainnya
    public void SetButtonColor(LevelButton button, Color color)
    {
        button.buttonImage.color = color;
    }

    // Metode ini dapat dipanggil untuk mengganti status kunci level (locked/unlocked)
    public void SetLevelLockStatus(LevelButton button, bool locked)
    {
        button.isLocked = locked;
        UpdateButtonColor(button);
    }
}
