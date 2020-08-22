using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator anim;
    public GameObject generalScreen;
    public GameObject viewCorrect;
    public GameObject viewIncorrect;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void gotoMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void goToCorrect()
    {
        generalScreen.SetActive(false);
        viewCorrect.SetActive(true);
    }

    public void goToIncorrect()
    {
        generalScreen.SetActive(false);
        viewIncorrect.SetActive(true);
    }

    public void goToGeneral()
    {
        generalScreen.SetActive(true);
        viewCorrect.SetActive(false);
        viewIncorrect.SetActive(false);
    }

    IEnumerator LoadLevel(int sceneIndex)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }
}
