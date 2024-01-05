using UnityEngine;

public class AnswerFeedback : MonoBehaviour
{
    public GameObject correctAnswerPanel;
    public GameObject wrongAnswerPanel;

    [ContextMenu("Show Game Over > Jawaban Benar")]
    public void ShowCorrectAnswerPanel()
    {
        correctAnswerPanel.SetActive(true);
        wrongAnswerPanel.SetActive(false);
    }

    [ContextMenu("Show Game Over > Jawaban Salah")]
    public void ShowWrongAnswerPanel()
    {
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(true);
    }

    public void HideFeedbackPanels()
    {
        correctAnswerPanel.SetActive(false);
        wrongAnswerPanel.SetActive(false);
    }
}
