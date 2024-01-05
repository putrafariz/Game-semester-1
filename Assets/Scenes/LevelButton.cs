using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    public int levelNumber;
    public bool isLocked = true;
    [HideInInspector] public Button button;
    [HideInInspector] public Image buttonImage;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
    }

}
