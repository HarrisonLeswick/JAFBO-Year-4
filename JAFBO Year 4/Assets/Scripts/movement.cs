using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private float playerSpeed = 2.0f;
    private Rigidbody2D playerHitbox;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerHitbox = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();


        if (Input.GetKey(KeyCode.W))
        {
            anim.Play("Nutmeg_Walk_Up");
        }

        else if (Input.GetKey(KeyCode.A))
        {
            anim.Play("Nutmeg_Walk_Left");
        }
        
        else if (Input.GetKey(KeyCode.S))
        {
            anim.Play("Nutmeg_Walk_Down");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            anim.Play("Nutmeg_Walk_Right");
        }

        else{
            anim.Play("Nutmeg_Idle");
        }


    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        playerHitbox.velocity = new Vector2(horizontalInput * playerSpeed, verticalInput * playerSpeed);

    }
}
