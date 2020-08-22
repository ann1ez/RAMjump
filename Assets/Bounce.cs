using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Bounce : MonoBehaviour
{
    public GameObject gameObejct;

   void OnCollisionEnter2D(Collision2D collision)
   {
       
       if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
       {
           collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 700F);
       }
   }
}
