using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:Left 1:middle 2:right
    public float laneDistance = 4;//the distance between two lanes

    public float jumpForce;
    public float Gravity = -20;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


     void Update()
    {
        if (!PlayerManager1.isGameStarted)
            return;

        //Increase the game speed
        if(forwardSpeed < maxSpeed)
            forwardSpeed += 0.1f * Time.deltaTime;

        direction.z = forwardSpeed;

        
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (SwipeManager1.swipeUp)
            {
                Jump();
                FindObjectOfType<AudioManager>().PlaySound("Jump");
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
        //Gather the inputs on which lane we should be 

        if (SwipeManager1.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager1.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    private void FixedUpdate()
    {
        if(!PlayerManager1.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager1.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}

  