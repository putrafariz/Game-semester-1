using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public int currentLevel;

    public Text questionText;
    public Button answerButton1;
    public Button answerButton2;
    public Button answerButton3;
    public Button answerButton4;
    public AnswerFeedback answerFeedback;
    public int questionIndex;

    public LevelButton levelButton;
    public GameObject continueButton;
    public GameObject backToLevelButton;
    public GameObject tryAgainButton;
    public GameObject backToLevelButtonWrong;
    public LevelButtonManager levelButtonManager;

    //this thing is so stupid why
    public string[] questions = { "Di bawah ini yang bukan merupakan sampah non-organik adalah", "Di bawah ini sampah yang memiliki nilai ekonomis contohnya kecuali", "Sampah organik dapat digunakan sebagai", "Suatu zat yang menyebabkan terjadinya pencemaran disebut", "Pencemaran yang diakibatkan oleh bakteri termasuk dalam pencemaran" };
    public string[,] answersOptions = { { "A. Bekas korek gas", "B.  Plastik bekas shampo", "C. Daun bungkus nasi pecel", "D. Gelas plastik" }, { "A. Kertas bekas", "B. Karet bekas", "C. Plastik bekas", "D. Nasi bekas" }, { "A. Bahan bakar", "B. Racun", "C. Pupuk alami", "D. Pengusir hama" }, { "A. Sampah", "B. Polutan", "C. Limbah", "D. Polusi" }, {"A. Biologis", "B. Kimiawi","C. Fisik","D. Tanah" } };
    private int[] correctAnswers = { 3, 4, 3, 2, 1 };
    public int questionScore = 100;
    public Text scoreText;
    public int currentScore;
    private int playerCorrectAnswer;

    public int timeEachQuestion = 11;
    [SerializeField] Text timerText;
    [SerializeField] private float remainingTime;


    void Start()
    {
        remainingTime = timeEachQuestion;
        questionIndex = 1;
        updateQuestionText();        
        int unlockedLevel = LevelSelector.currentUnlockedLevel;
        // Setiap tombol terkait dengan metode yang sesuai untuk menanggapi klik
        answerButton1.onClick.AddListener(AnswerButton1Clicked);
        answerButton2.onClick.AddListener(AnswerButton2Clicked);
        answerButton3.onClick.AddListener(AnswerButton3Clicked);
        answerButton4.onClick.AddListener(AnswerButton4Clicked);

        // Sembunyikan tombol-tombol pada awal
        HideAllButtons();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime <= 0)
        {
            remainingTime = 0;
            if (questionIndex < 6) {
                questionIndex++;
                updateQuestionText();
                updateScore();
            }
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void AnswerButton1Clicked()
    {
        if (correctAnswers[questionIndex - 1] == 1) { 
        correctAnswer();
        }
        else
        {
            questionIndex++;
            updateQuestionText();
            updateScore();
        };
    }

    void AnswerButton2Clicked()
    {
        if (correctAnswers[questionIndex - 1] == 2)
        {
            correctAnswer();
        }
        else
        {
            questionIndex++;
            updateQuestionText();
            updateScore();
        };
    }

    void AnswerButton3Clicked()
    {
        if (correctAnswers[questionIndex - 1] == 3)
        {
            correctAnswer();
        }
        else
        {
            questionIndex++;
            updateQuestionText();
            updateScore();
        };

    }

    void AnswerButton4Clicked()
    {
        if (correctAnswers[questionIndex - 1] == 4)
        {
            correctAnswer();
        }
        else
        {
            questionIndex++;
            updateQuestionText();
            updateScore();
        };
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

    void updateQuestionText()
    {
        if (questionIndex < 6)
        {
            if (questionIndex >= 1)
            {
                questionText.text = questions[questionIndex - 1];
            }
            Text button1 = answerButton1.GetComponentInChildren<Text>();
            button1.text = answersOptions[questionIndex - 1, 0];
            Text button2 = answerButton2.GetComponentInChildren<Text>();
            button2.text = answersOptions[questionIndex - 1, 1];
            Text button3 = answerButton3.GetComponentInChildren<Text>();
            button3.text = answersOptions[questionIndex - 1, 2];
            Text button4 = answerButton4.GetComponentInChildren<Text>();
            button4.text = answersOptions[questionIndex - 1, 3];

            //for (int i= 0; i < 5; i++){
            //    int num = i + 1;
            //    Text buttonText = answerButton1.GetComponentInChildren<Text>();
            //    buttonText= 
            //}

            Debug.Log("The question text should've been updated by now. Current question index = " + questionIndex);
            Debug.Log("In case you forgot what's the correct answer =  " + correctAnswers[questionIndex - 1]);
        }
        else
        {
            answerFeedback.ShowCorrectAnswerPanel();
            int level = currentLevel;
            if (level == LevelSelector.currentUnlockedLevel)
            {
            LevelSelector.currentUnlockedLevel++;
            }
            Debug.Log("Current unlocked level : " + LevelSelector.currentUnlockedLevel);
            ShowCorrectAnswerButtons();
        }
    }
    void correctAnswer()
    {
        
        Debug.Log("Jawaban Benar!");
        //answerFeedback.ShowCorrectAnswerPanel();
        //ShowCorrectAnswerButtons();
        questionIndex++;
        updateQuestionText();
        currentScore += questionScore * (int)remainingTime;
        updateScore();
        playerCorrectAnswer++;
    }
    void updateScore()
    {
        Debug.Log("socer : " + currentScore);
        scoreText.text = "Score : " + currentScore;
        remainingTime = timeEachQuestion;
    }
    public void BackToLevelSelection()
    {
        Debug.Log("Tombol Kembali ke Pilih Level Diklik");

        // Pindah ke scene "Main Menu" menggunakan skrip PindahScene
        FindObjectOfType<PindahScene>().scene("Level");
    }
}

