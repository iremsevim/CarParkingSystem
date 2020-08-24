using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{  
    public float acceleration;
    private Rigidbody2D rb;

    public List<Collider2D> parkobjects;

     void Start () 
     {
         rb = GetComponent<Rigidbody2D>();
     }
 
     void FixedUpdate ()
    {
         float updown= Input.GetAxis("Vertical");
 
         Vector2 speed = transform.up * (updown * acceleration);
         rb.AddForce(speed);

         rb.velocity=new Vector2(Mathf.Clamp(rb.velocity.x,-2f,2f),Mathf.Clamp(rb.velocity.y,-2f,2f));
     }
}
