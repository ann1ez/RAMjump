using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Controller : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
   public int health = 3;
   public Text infoPause;

   private Rigidbody2D rb2d;
   private float dirX; //private float moveInput;
   private float speed = 20f;
   private bool isStarted = false;
   private bool restart = false;
   
   private float topScore = 0.0f;
   private ScoreManager scoreManager;
   public Text scoreText;
   private GameController gameController;
   private string answer;
   public GameObject startButton;

   // Start is called before the first frame update
   void Start()
   {
       rb2d = GetComponent<Rigidbody2D>();
       rb2d.gravityScale = 0;
       rb2d.velocity = Vector3.zero;
       scoreManager = GameObject.FindObjectOfType<ScoreManager>();
       scoreText.text = "SCORE";
       gameController = GameObject.FindObjectOfType<GameController>();
       heart3.gameObject.SetActive(true);
       heart2.gameObject.SetActive(true);
       heart1.gameObject.SetActive(true);
       scoreManager.clear();
   }

   public void startGame()
   {
        isStarted = true;
        rb2d.gravityScale = 4.5f;
        startButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 700F);
   }

   // Update is called once per frame
   void Update()
   {
    //    if(Input.GetKeyDown(KeyCode.Space) && isStarted == false)                        //starting the game  
    //    {
    //        isStarted = true;
    //        startText.gameObject.SetActive(false);
    //        rb2d.gravityScale = 4.5f;
    //        Time.timeScale = 1;
    //        this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 700F);
    //    }
       if(restart == true)                                                              //restarting the game
       {
           //startText.gameObject.SetActive(true);
           startButton.gameObject.SetActive(true);
           Time.timeScale = 0;
           restart = false;
           isStarted = false;
           rb2d.gravityScale = 0f;
           rb2d.velocity = Vector3.zero;
           rb2d.AddForce(Vector3.down * 700F);
       }
       if(isStarted == true && Time.timeScale == 1)                                     //updating the score
       {
           dirX = Input.acceleration.x * speed;
            if(dirX < 0)                                                                //moveInput < 0
                {this.GetComponent<SpriteRenderer>().flipX = false;}
            else
                {this.GetComponent<SpriteRenderer>().flipX = true;}

            if(rb2d.velocity.y > 0 && transform.position.y > topScore)
                {topScore = transform.position.y;}

            scoreManager.UpdateScore(topScore);
       }
       switch (health){
           case 3:
                heart3.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                break;
           case 2:
                heart3.gameObject.SetActive(false);
                break;
           case 1:
                heart2.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                break;
       }
   }
   
   void FixedUpdate()
   {
       if(isStarted == true)
       {
            //moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(dirX, rb2d.velocity.y); //moveInput * speed
       }
   }

   public void updateAnswer(string Answer)
   {
       answer = Answer;
   }

   void OnCollisionEnter2D(Collision2D collision)
   {
       if(collision.gameObject.name.StartsWith(answer) && rb2d.velocity.y <= 0)
       {
           infoPause.text = "Correct! " + gameController.question + ". Next Question:";
           scoreManager.UpdateCorrect(gameController.question);
           gameController.newQuestion();
           gameController.pauseFunction();
           restart = true;
       }
       else if(!collision.gameObject.name.StartsWith("Platform") && rb2d.velocity.y <= 0 && !collision.gameObject.name.StartsWith("Spring"))
       {
           scoreManager.UpdateMissed(gameController.question);
           health -= 1;
           if(health > 0)
           {
                infoPause.text = "Incorrect! " + gameController.question + ". Next Question:";
                gameController.newQuestion();
                gameController.pauseFunction();
                restart = true;
           }
           else
           {
               infoPause.text = "Incorrect! " + gameController.question;
               gameController.questionPause.text = "";
               gameController.pauseFunction();
               gameController.isGameOver2 = true;
           }
           
       }
   }
}
