using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // player is alive
    bool alive = true;

    //start default speed is 5
    public float speed = 5;
    [SerializeField]public Rigidbody rb;

    //control player horizontal movement 
    [SerializeField]float horizontalInput;

    //Increase player speed, check game manager too to disable or enable
    public float speedIncreasePerPoint = 0.1f;

    //Allow player to jump
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        //if player is not alive mean player cannot move
        if (!alive) return; 

        //enable player to move forward
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //make player go left or right upon detecting input or control
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Update()
    {
        //control or input to move player horizontally
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //if player fall off map this will kill the player
        if (transform.position.y < -30)
        {
            Die();
        }
    }

    public void Die()
    {
        //Restart the game
        alive = false;
        Invoke("Restart", 3);
    }

    void Restart()
    {
        //load the level upon restart or player death
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Jump()
    {
        //Check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //If we are, jump
        rb.AddForce(Vector3.up * jumpForce);
    }
}
