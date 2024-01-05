using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToLevelSelection();
        }
    }

    public void BackToLevelSelection()
    {
        Debug.Log("BackToLevelSelection Called");
        // Tambahkan logika Anda di sini
    }
}
