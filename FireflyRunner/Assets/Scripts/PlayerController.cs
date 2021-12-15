using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private bool doubleJump = true;
    public GameObject gameOverBanner;
    private static Vector3 grav;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        if (Physics.gravity != grav)
        {
            Physics.gravity *= gravityModifier;
            grav = Physics.gravity;
            Debug.Log(Physics.gravity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log("JUMP");
        }
        else if (Input.GetMouseButtonDown(0) && !isOnGround && doubleJump && !gameOver)
        {

            playerRb.velocity = new Vector3(playerRb.velocity.y, 0f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doubleJump = false;
            Debug.Log("DOUBLE JUMP");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = true;
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            gameOver = true;
            gameOverBanner.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
