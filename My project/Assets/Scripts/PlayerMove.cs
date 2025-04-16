using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController character;
    public Transform playerTransform;
    public float initialYPosition;
    public float targetXPosition;
    public float moveDistance = 6.5f;
    public bool isJumping = false;
    public float verticalSpeed = 0f;
    public float jumpHeight = 9;
    public Animator playerAnimator;
    public float smoothTime = 0.1f;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        playerTransform = transform;
        initialYPosition = playerTransform.position.y;
        targetXPosition = playerTransform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Vector3 currentPosition = playerTransform.position;
        Vector3 NewPosition = new Vector3(targetXPosition, currentPosition.y, currentPosition.z);
        playerTransform.position = Vector3.Lerp(currentPosition, NewPosition, smoothTime);
        HandleJump(); 
        if (playerTransform.position == NewPosition){
            isMoving = false;
        }
    }

    private void Movement()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isMoving == false){
            MoveLeft();
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isMoving == false){
            MoveRight();
        }
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping && isMoving == false){
            MoveJump();
        }
    }

    private void MoveLeft()
    {
        isMoving = true;
        targetXPosition = Mathf.Clamp(targetXPosition - moveDistance, -moveDistance, moveDistance);
    }
    private void MoveRight()
    {
        isMoving = true;
        targetXPosition = Mathf.Clamp(targetXPosition + moveDistance, -moveDistance, moveDistance);
    }
    private void MoveJump()
    {
        isMoving = true;
        isJumping = true;
        verticalSpeed = CalculateJumpSpeed(jumpHeight);
        playerAnimator.SetTrigger("jump");
    }
    private float CalculateJumpSpeed(float jumpHeight)
    {
        return Mathf.Sqrt(2*Mathf.Abs(Physics.gravity.y)*jumpHeight);
    }
    public void HandleJump()
    {
        if (isJumping){
            verticalSpeed += Physics.gravity.y * 2.5f * Time.deltaTime;
            Vector3 verticalMovement = new Vector3(0, verticalSpeed, 0) * Time.deltaTime;
            character.Move(verticalMovement);
            if (character.isGrounded && verticalSpeed < 0){
                isJumping = false;
                verticalSpeed = 0;
                Vector3 groundedPosition = playerTransform.position;
                groundedPosition.y = initialYPosition;
                playerTransform.position = groundedPosition;
                playerAnimator.ResetTrigger("jump");
            }
        }
    }
}
