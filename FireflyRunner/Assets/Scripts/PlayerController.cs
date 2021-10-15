using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier =1.5f;
    public bool isOnGround = true;
    public bool gameOver;
    private bool doubleJump = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log("Player jumped.");
        }
        else if (Input.GetMouseButtonDown(0) && !isOnGround && doubleJump && !gameOver)
        {

            playerRb.velocity = new Vector3(playerRb.velocity.y, 0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doubleJump = false;
            Debug.Log("Player double jumped.");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision with ground detected.");
            isOnGround = true;
            doubleJump = true;
        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle detected. The game is over.");
            gameOver = true;
        }
    }
}
