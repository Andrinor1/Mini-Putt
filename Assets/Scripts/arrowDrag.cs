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
    private Vector2 mouseStart;

    void Awake()
    {
        // The ball can be clicked directly, but this allows the screen to be clicked and dragged as well
        GameEvents.instance.onMousePressed += OnMouseDown;
        GameEvents.instance.onMouseReleased += OnMouseUp;
        GameEvents.instance.onMouseCancel += OnMouseUp;
        mouseStart = ballRigidBody.position;
    }

    void OnDestroy()
    {
        GameEvents.instance.onMousePressed -= OnMouseDown;
        GameEvents.instance.onMouseReleased -= OnMouseUp;
        GameEvents.instance.onMouseCancel -= OnMouseUp;
    }

    public void OnMouseDown()
    {
        if (ballRigidBody.velocity == Vector2.zero)
        {
            directionArrow.SetActive(true);
            // Getting the position of the mouse in terms of game units
            mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
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
            Vector2 mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mouseStart.magnitude == mouseEnd.magnitude)
            {
                directionArrow.transform.position = new Vector3(999, 999, -5);
                return;
            }

            // Finding the difference in positions between when the mouse was clicked and the current mouse position
            Vector2 positionDifference = (mouseStart - mouseEnd);
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
            directionArrow.transform.position = new Vector3(ballRigidBody.position.x + positionDifference.x,
                                                            ballRigidBody.position.y + positionDifference.y,
                                                            -5);

        }
    }
}
