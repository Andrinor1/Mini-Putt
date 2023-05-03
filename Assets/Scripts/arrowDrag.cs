using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrowDrag : MonoBehaviour
{
    public GameObject directionArrow;
    public Rigidbody2D ballRigidBody;
    public ClickAndDrag clickAndDragScript;
    public CircleCollider2D circleCollider;
    private bool ballPressed = false;

    public void OnMouseDown()
    {
        if (!ballPressed)
        {
            ballPressed = true;
            directionArrow.SetActive(true);
        }
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
        if (clickAndDragScript.ballStopped && Input.GetMouseButton(0) && ballPressed)
        {
            // Getting the position of the mouse in terms of game units
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Finding the difference in positions between the ball and the mouse
            Vector2 positionDifference = ballRigidBody.position - mousePosition;

            // Angle of the ball is now that of what is calculated. This, in term, rotates the DirectionArrow
            var angle = 180 - Mathf.Atan2(positionDifference.x, positionDifference.y) * Mathf.Rad2Deg;
            ballRigidBody.rotation = angle;

            // If mouse position is too close to ball, then change positionDifference so that arrow is not too close
            if (positionDifference.magnitude < circleCollider.radius * 2)
                positionDifference = positionDifference.normalized * circleCollider.radius * 2;

            // Setting the position of the directionArrow such that it's opposite of the ball
            directionArrow.transform.position = ballRigidBody.position + positionDifference;
        }
    }
}
