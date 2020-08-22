using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public bool isGameOver = false;
    public bool isGameOver2 = false;
    public Animator anim;
    public bool pause;
    public GameObject pauseScreen;
    public GameObject playScreen;
    public int a;
    public int b;
    public int correct;
    public int wrong;
    public string answer;
    public Text questionPause;
    public Text questionPlay;
    private Controller playerController;
    public string question;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<Controller>();
        newQuestion();
        pauseScreen.SetActive(true);
        pause = true;
    }

    // Update is called once per frame
    void Update()
    {   
        if(isGameOver == true || (isGameOver2 == true && pause == false))
        {
            StartCoroutine(LoadLevel(2));
        }
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }

    public void pauseFunction()
    {
        pause = !pause;
        pauseScreen.SetActive(pause);
        playScreen.SetActive(!pause);

        if(pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void newQuestion()
    {
        a = Random.Range(1, 11);
        b = Random.Range(1, 21);
        correct = a * b;

        int[] wrongAnswers = {(a-1)*b, (a+1)*b, (b-1)*a, (b+1)*a};
        wrong = wrongAnswers[Random.Range(0, 4)];

        if(Random.Range(0,2) == 0)
        {
            answer = "Option2";
            foreach(var optionOne in FindObjectsOfType(typeof(Option1)) as Option1[])                   //assigning wrong on left side
            {
                optionOne.changeOption1(wrong);
            }
            foreach(var optionTwo in FindObjectsOfType(typeof(Option2)) as Option2[])
            {
                optionTwo.changeOption1(correct);
            }
        }
        else{
            answer = "Option1";
            foreach(var optionOne in FindObjectsOfType(typeof(Option1)) as Option1[])                   //assigning wrong on right side
            {
                optionOne.changeOption1(correct);
            }
            foreach(var optionTwo in FindObjectsOfType(typeof(Option2)) as Option2[])
            {
                optionTwo.changeOption1(wrong);
            }
        }
        questionPause.text = a + " x " + b + "?";
        questionPlay.text = a + " x " + b; 
        playerController.updateAnswer(answer);
        question  = a + " x " + b + " = " + correct;
    }

}
