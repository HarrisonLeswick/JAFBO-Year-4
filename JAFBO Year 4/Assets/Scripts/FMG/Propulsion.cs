using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsion : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Fixed Update because physics baby
    void FixedUpdate()
    {
        //add force in forward facing direction (limited by total velocity magnitude to have a less static top speed, 
        //while still holding a restriction)
        if(Input.GetKey(KeyCode.W) && rigidBody.velocity.magnitude < 5)
        {
            rigidBody.AddForce(transform.up);
        }

        //SIDE POINT:
        //deceleration is handled inside the core physics sim through a physics material rather than through any script

        //rotate CCW
        if(Input.GetKey(KeyCode.A))
        {
            //rotation maths
            transform.rotation *= Quaternion.Euler(0.0f,0.0f,0.5f);
        }

        //rotate CW
        else if(Input.GetKey(KeyCode.D))
        {
            //inverse rotation maths
            transform.rotation *= Quaternion.Euler(-0.0f,-0.0f,-0.5f);
        }
    }
}
