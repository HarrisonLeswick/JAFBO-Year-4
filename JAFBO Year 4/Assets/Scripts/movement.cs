using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    [SerializeField] private float playerSpeed = 2.0f;
    private Rigidbody2D playerHitbox;
    // Start is called before the first frame update
    void Start()
    {
        playerHitbox = GetComponent<Rigidbody2D>();
        if (playerHitbox == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        playerHitbox.velocity = new Vector2(horizontalInput * playerSpeed, verticalInput * playerSpeed);

    }
}
