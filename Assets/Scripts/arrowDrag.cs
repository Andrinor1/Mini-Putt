using System.Collections;
using System.Collections.Generic;
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
    private Vector2 mouseOrigin;

    void Awake()
    {
        // The ball can be clicked directly, but this allows the screen to be clicked and dragged as well
        GameEvents.current.onMousePressed += OnMouseDown;
        GameEvents.current.onMouseReleased += OnMouseUp;
        GameEvents.current.onMouseCancel += OnMouseUp;
        mouseOrigin = ballRigidBody.position;
    }

    void OnDestroy()
    {
        GameEvents.current.onMousePressed -= OnMouseDown;
        GameEvents.current.onMouseReleased -= OnMouseUp;
        GameEvents.current.onMouseCancel -= OnMouseUp;
    }

    public void OnMouseDown()
    {
        directionArrow.SetActive(true);
        // Getting the position of the mouse in terms of game units
        mouseOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseUp()
    {
        directionArrow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Getting the position of the mouse in terms of game units
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Finding the difference in positions between when the mouse was clicked and the current mouse position
            Vector2 positionDifference = (mouseOrigin - mousePosition);
            positionDifference /= 2;

            // Getting the angle of when the mouse was clicked vs. the current mouse position and setting the angle of the arrow.
            var angle = 180 - Mathf.Atan2(positionDifference.x, positionDifference.y) * Mathf.Rad2Deg;
            ballRigidBody.rotation = angle;

            // If mouse position is too close to ball, then change positionDifference so that arrow is not too close
            if (positionDifference.magnitude < circleCollider.radius * minDistanceFromBall)
                positionDifference = positionDifference.normalized * circleCollider.radius * minDistanceFromBall;
            else if (positionDifference.magnitude > circleCollider.radius * maxdistanceFromBall)
                positionDifference = positionDifference.normalized * circleCollider.radius * maxdistanceFromBall;

            // Setting the position of the directionArrow such that it's opposite of the ball
            directionArrow.transform.position = ballRigidBody.position + positionDifference;

        }
    }
}
