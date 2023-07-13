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

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) && rigidBody.velocity.magnitude < 5)
        {
            rigidBody.AddForce(transform.up);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation *= Quaternion.Euler(0.0f,0.0f,0.5f);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            transform.rotation *= Quaternion.Euler(-0.0f,-0.0f,-0.5f);
        }
    }
}
