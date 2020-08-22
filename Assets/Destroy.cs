using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.name.StartsWith("Platform"))
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(-13.0f, 13.0f), player.transform.position.y + (16 + Random.Range(0.2f, 0.5f)));
        }
        else if(collision.gameObject.name.StartsWith("Spring"))
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(-15.5f, 15.5f), player.transform.position.y + (16 + Random.Range(0.2f, 0.5f)));
        }
        else if(collision.gameObject.name.StartsWith("Option1"))
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(-15.5f, -13.0f), player.transform.position.y + (16 + Random.Range(0.2f, 0.5f)));
        }
        else if(collision.gameObject.name.StartsWith("Option2"))
        {
            collision.gameObject.transform.position = new Vector2(Random.Range(13.0f, 15.5f), player.transform.position.y + (16 + Random.Range(0.2f, 0.5f)));
        }

    }
}
