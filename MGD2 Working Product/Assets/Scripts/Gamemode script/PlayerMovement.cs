using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // player is alive
    bool alive = true;

    //start default speed is 5
    public float speed = 5;
    public Rigidbody rb;

    //control player horizontal movement 
    float horizontalInput;

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
}
