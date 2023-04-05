using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;



    public GameObject QuizPanel;
    public GameObject GOPanel;

    public TextMeshProUGUI QuestionTxt;

    private void Start()
    {
        GOPanel.SetActive(false);
        generateQuestion();
    }

    public void GameOver()
    {
        QuizPanel.SetActive(false);
        GOPanel.SetActive(true);

    }

    public void correct()
    {
        Debug.Log("Correct Answer");
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    public void retry()
    {
        SceneManager.LoadScene("GameMode");
    }

    public void wrong()
    {
        //when you answer wrong, the answer selected should turn red and stay on the same question
        Debug.Log("Wrong Answer");
     
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(0.5f);
        generateQuestion();
    }


    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;


            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
            }
           
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out Of Questions");
            GameOver();
        }

        
    }

}
