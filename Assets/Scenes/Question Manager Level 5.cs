using UnityEngine;
using UnityEngine.UI;

public class QuestionManagerLevel5 : MonoBehaviour
{
    public int currentLevel;

    public Text questionText;
    public Button answerButton1;
    public Button answerButton2;
    public Button answerButton3;
    public Button answerButton4;
    public AnswerFeedback answerFeedback;

    public LevelButton levelButton;
    public GameObject continueButton;
    public GameObject backToLevelButton;
    public GameObject tryAgainButton;
    public GameObject backToLevelButtonWrong;
    public LevelButtonManager levelButtonManager;

    void Start()
    {
        int unlockedLevel = LevelSelector.currentUnlockedLevel;
        // Setiap tombol terkait dengan metode yang sesuai untuk menanggapi klik
        answerButton1.onClick.AddListener(AnswerButton1Clicked);
        answerButton2.onClick.AddListener(AnswerButton2Clicked);
        answerButton3.onClick.AddListener(AnswerButton3Clicked);
        answerButton4.onClick.AddListener(AnswerButton4Clicked);

        // Sembunyikan tombol-tombol pada awal
        HideAllButtons();

    }

    void AnswerButton1Clicked()
    {
        correctAnswer();
    }

    void AnswerButton2Clicked()
    {
        wrongAnswer();
    }

    void AnswerButton3Clicked()
    {
        wrongAnswer();
    }

    void AnswerButton4Clicked()
    {
        wrongAnswer();
    }

    void ShowCorrectAnswerButtons()
    {
        continueButton.SetActive(true);
        backToLevelButton.SetActive(true);
        tryAgainButton.SetActive(false);
        backToLevelButtonWrong.SetActive(false);
    }

    void ShowWrongAnswerButtons()
    {
        tryAgainButton.SetActive(true);
        backToLevelButtonWrong.SetActive(true);
        continueButton.SetActive(false);
        backToLevelButton.SetActive(false);
    }

    void HideAllButtons()
    {
        continueButton.SetActive(false);
        backToLevelButton.SetActive(false);
        tryAgainButton.SetActive(false);
        backToLevelButtonWrong.SetActive(false);
    }

    void wrongAnswer()
    {
        Debug.Log("Jawaban Salah!");
        answerFeedback.ShowWrongAnswerPanel();
        ShowWrongAnswerButtons();
    }

    [ContextMenu("[DEBUG] - Add Unlocked Level")]
    void addUnlockedLevel()
    {
        LevelSelector.currentUnlockedLevel++;
        Debug.Log("Current unlocked level : " + LevelSelector.currentUnlockedLevel);
    }

    void correctAnswer()
    {
        int level = currentLevel;
        Debug.Log("Jawaban Benar!");
        answerFeedback.ShowCorrectAnswerPanel();
        ShowCorrectAnswerButtons();

        if (level == LevelSelector.currentUnlockedLevel)
        {
            LevelSelector.currentUnlockedLevel++;
        }
        Debug.Log("Current unlocked level : " + LevelSelector.currentUnlockedLevel);

        // Mungkin tambahkan logika tambahan khusus untuk level 2 di sini
        // Contoh: Memuat pertanyaan baru atau menyesuaikan skor pemain.
    }

    public void BackToLevelSelection()
    {
        Debug.Log("Tombol Kembali ke Pilih Level Diklik");

        // Pindah ke scene "Main Menu" menggunakan skrip PindahScene
        FindObjectOfType<PindahScene>().scene("Level");
    }
}
