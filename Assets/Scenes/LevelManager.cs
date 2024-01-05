using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Jumlah total level dalam permainan
    public int totalLevels = 5;

    // Level yang terkunci awalnya
    private int lockedLevels = 4;

    void Start()
    {
        // Membuka level yang telah terkunci
        UnlockLevels();
    }

    void Update()
    {
        // Tombol kembali untuk kembali ke scene sebelumnya
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc pressed");
            BackToPreviousScene();
        }
    }

    // Method untuk membuka level yang telah terkunci
    void UnlockLevels()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            // Mengecek apakah level ini terkunci
            if (i <= lockedLevels)
            {
                PlayerPrefs.SetInt("Level" + i.ToString(), 1); // 1 menunjukkan level terbuka
            }
            else
            {
                PlayerPrefs.SetInt("Level" + i.ToString(), 0); // 0 menunjukkan level terkunci
            }
        }
        PlayerPrefs.Save();
    }

    // Method untuk pindah ke level tertentu
    public void GoToLevel(int level)
    {
        // Mengecek apakah level telah terbuka sebelum pindah
        if (PlayerPrefs.GetInt("Level" + level.ToString()) == 1)
        {
            SceneManager.LoadScene("Level" + level.ToString());
        }
        else
        {
            Debug.Log("Level " + level + " terkunci! Tidak dapat pindah ke level ini.");
        }
    }

    // Method untuk kembali ke scene sebelumnya
    void BackToPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Jika bukan scene pertama, kembali ke scene sebelumnya
        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }
}
