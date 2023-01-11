using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// Create a topdown 2d movement script for player that movees to position clicked
public class PlayerMovement : MonoBehaviour
{
    // Speed of the character's movement
    public float speed = 5f;

    // Reference to the character's animator component
    private Animator animator;
    private Vector2 targetPosition;

    // Reference to the character's rigidbody component
    private Rigidbody2D rb;

    // Flag to track if the character is currently moving
    public bool isMoving = false;

    void Start()
    {
        // Get references to the animator and rigidbody components
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the left mouse button is clicked
        // and check if the click is not on a UI element
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            // Get the position of the mouse click
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the direction to the target position
            Vector2 direction = targetPosition - rb.position;

            // Normalize the direction to get the unit vector
            direction.Normalize();

            // Set the character's velocity to the direction and speed
            rb.velocity = direction * speed;

            // Set the flag to indicate that the character is moving
            isMoving = true;

            // Update the character's animation state
            UpdateAnimationState(direction);
        }
        else if (isMoving)
        {
            // If the character is moving, check if it has reached the target position
            float distance = Vector2.Distance(rb.position, targetPosition);
            if (distance < 0.1f)
            {
                // If the character is close enough to the target position, stop moving
                rb.velocity = Vector2.zero;
                isMoving = false;
                UpdateAnimationState(Vector2.zero);
            }
        }
    }

    void UpdateAnimationState(Vector2 direction)
    {
        // Set the horizontal and vertical animation parameters based on the direction of movement
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);

        // Set the idle animation state
        animator.SetBool("isIdle", !isMoving);
    }
}