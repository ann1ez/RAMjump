using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text correctText;
    public Text incorrectText;
    public static string correct = "";
    public static string incorrect = "";
    static public float score = 0;


    void Start()
    {
        scoreText.text = score.ToString() + "!";
        correctText.text = correct;
        // foreach(string q in correctQuestions)
        // {
        //     correctText.text += q + "\n";
        // }

        incorrectText.text = incorrect;
        // foreach(string q in missedQuestions)
        // {
        //     incorrectText.text += q + "\n";
        // }
    }

    public void clear()
    {
        correct = "";
        incorrect = "";
    }
    
    public void UpdateScore(float topScore)
    {
        score = Mathf.Round(topScore);
        scoreText.text = "SCORE: " + score.ToString();
    }

    public void UpdateMissed(string question)
    {
        incorrect += question + "\n";
    }

    public void UpdateCorrect(string question)
    {
        correct += question + "\n";
    }
}
