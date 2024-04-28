using System.Collections;
using System.Collections.Generic;
// ThirdPersonMovement.cs
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float runSpeedMultiplier = 2f;

    private bool isRunning = false;

    void Update()
    {
        // Move player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Rotate player based on camera's forward direction
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Move player
            float speed = isRunning ? moveSpeed * runSpeedMultiplier : moveSpeed;
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Set walking animation
            animator.SetBool("isWalking", true);

            // Set running animation if shift is held
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRunning = true;
                animator.SetBool("isRunning", true);
            }
            else
            {
                isRunning = false;
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            // Not moving
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }
}
