using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRB; // declare the player rigidbody

    public float movementSpeed, jumpForce; // declare floats for movement speed and jump force
    private Vector2 movementInput; // get input for movement
    public float fallMultiplier = 2.5f; // float to multiply the fall after a jump
    public float smallJumpMultiplier = 2f; // float to multiply a smaller jump


    public LayerMask whatIsGround;
    public Transform GroundCheck;
    private bool isGrounded;

    public Animator playerAnim;
    public SpriteRenderer playerSR; //calling reference to the player sprite renderer
    public Animator flipAnim;

    public AudioSource walkAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");
        movementInput.Normalize();// prevent speed increase when moving diagonally

        playerRB.velocity = new Vector3(movementInput.x * movementSpeed, playerRB.velocity.y, movementInput.y * movementSpeed);

        playerAnim.SetFloat("Speed", playerRB.velocity.magnitude); // checking how fast the player is moving and assigning to animator


        // check if player is grounded using raycast
        RaycastHit hit;
        if(Physics.Raycast(GroundCheck.position, Vector3.down, out hit, .3f, whatIsGround))
        {

            isGrounded = true;

        } else
        {

            isGrounded = false;

        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {

            playerRB.velocity += new Vector3(0f, jumpForce, 0f);

        }

        if (playerRB.velocity.y < 0) // if the player is falling
        {
            playerRB.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; // multiply the gravity by the fall multiplier - 1

        } else if (playerRB.velocity.y > 0 && !Input.GetButton ("Jump")) // If the player is jumping but not holding the jump button
        {

            playerRB.velocity += Vector3.up * Physics.gravity.y * (smallJumpMultiplier - 1) * Time.deltaTime; // multiply the gravity by the small jump multiplier - 1

        }

        playerAnim.SetBool("onGround", isGrounded); // checking whether player is grounded or not and assigning to animator

        if(!playerSR.flipX && movementInput.x > 0) // if the player is moving to the left
        {

            playerSR.flipX = true; // set x flip to false
            flipAnim.SetTrigger("Flip");

        } else if(playerSR.flipX && movementInput.x < 0) // if the player is moving to the right
        {

            playerSR.flipX = false; // set x flip to true
            flipAnim.SetTrigger("Flip");

        }

    }
}