using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrowDrag : MonoBehaviour
{
    public GameObject directionArrow;
    [Header("Distance is compared against ball radius x value")]
    public float minDistanceFromBall = 2.0f;
    public float maxdistanceFromBall = 5.0f;
    [Header("Drag 'ball' object into these parameters")]
    public Rigidbody2D ballRigidBody;
    public CircleCollider2D circleCollider;
    private bool ballPressed = false;

    public void OnMouseDown()
    {
        if (!ballPressed)
        {
            ballPressed = true;
            directionArrow.SetActive(true);
        }
        Debug.Log("Mouse Downed");
    }

    public void OnMouseUp()
    {
        if (ballPressed)
        {
            ballPressed = false;
            directionArrow.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && ballPressed)
        {
            // Getting the position of the mouse in terms of game units
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Finding the difference in positions between the ball and the mouse
            Vector2 positionDifference = (ballRigidBody.position - mousePosition);
            positionDifference /= 2;

            // Angle of the ball is now that of what is calculated. This, in term, rotates the DirectionArrow
            var angle = 180 - Mathf.Atan2(positionDifference.x, positionDifference.y) * Mathf.Rad2Deg;
            ballRigidBody.rotation = angle;

            //Debug.Log("Before: " + positionDifference);

            // If mouse position is too close to ball, then change positionDifference so that arrow is not too close
            if (positionDifference.magnitude < circleCollider.radius * minDistanceFromBall)
            {
                // positionDifference /= 2;
                // Debug.Log("After: " + positionDifference);
                positionDifference = positionDifference.normalized * circleCollider.radius * minDistanceFromBall;
            }
            else if (positionDifference.magnitude > circleCollider.radius * maxdistanceFromBall)
            {
                positionDifference = positionDifference.normalized * circleCollider.radius * maxdistanceFromBall;
            }

            // Debug.Log("After: " + positionDifference);

            // Setting the position of the directionArrow such that it's opposite of the ball
            directionArrow.transform.position = ballRigidBody.position + positionDifference;
        }
    }
}
