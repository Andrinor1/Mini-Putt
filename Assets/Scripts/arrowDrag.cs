using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDrag : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody2D ballRigidBody;
    private ClickAndDrag clickAndDragScript;
    private CircleCollider2D circleCollider;
    private bool ballPressed = false;
    Vector2 mousePosition;

    public void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        clickAndDragScript = ball.GetComponent<ClickAndDrag>();
        circleCollider = ball.GetComponent<CircleCollider2D>();
    }

    public void OnMouseDown()
    {
        //Debug.Log("ballPressed: " + ballPressed);
        //if (!ballPressed)
        //{
        //    // Getting the position of the mouse in terms of game units
        //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    // Finding the difference in positions between the ball and the mouse
        //    Vector2 dir = ballRigidBody.position - mousePosition;
        //    Debug.Log("dir: " + dir);
        //    Debug.Log("dir.magnitude: " + dir.magnitude);

        //    if (dir.magnitude <= circleCollider.radius)
        //    {
        //        ballPressed = true;
        //    }
        //}
    }

    public void OnMouseUp()
    {
        if (ballPressed)
            ballPressed = false;
    }

    private void Update()
    {
        if (clickAndDragScript.ballStopped && Input.GetMouseButton(0))
        {
            Debug.Log("This hsould work");
            gameObject.SetActive(true);
            // Getting the position of the mouse in terms of game units
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Finding the difference in positions between the ball and the mouse
            Vector2 dir = ballRigidBody.position - mousePosition;

            // Setting the position of the triangle to that opposite of the ball
            transform.position = ballRigidBody.position + dir;

            // Angle of the ball is now that of what is calculated. This, in term, rotates the triangle
            var angle = 180 - Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            ballRigidBody.rotation = angle;
        }
    }
}
