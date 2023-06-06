using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private ScoreKeeper scorekeeper;

    public float velocityScale = 1;

    private Rigidbody2D body;
    private float force;
    [HideInInspector] public bool ballStopped = true;
    private bool hit = false;
    private Vector3 ballDirection;
    private Vector3 mouseStart;
    private Vector3 mouseEnd;

    void Awake()
    {
        scorekeeper = ScoreKeeper.Instance; // Assign the `gameManager` variable by using the static reference
        body = GetComponent<Rigidbody2D>();
        GameEvents.current.onMousePressed += OnMouseDown;
        GameEvents.current.onMouseReleased += OnMouseUp;
    }

    void OnDestroy()
    {
        GameEvents.current.onMousePressed -= OnMouseDown;
        GameEvents.current.onMouseReleased -= OnMouseUp;
    }

    void Update()
    {
        if (body.velocity == Vector2.zero && !ballStopped)
        {
            ballStopped = true;
            // Add something to increase number of shots taken? Or should that be done when the ball is first shot?
            body.angularVelocity = 0;
            //Debug.Log("Stopped!");
        }
    }

    private void FixedUpdate()
    {
        if (hit)
        {
            hit = false;
            ballStopped = false;
            ballDirection = mouseStart - mouseEnd;

            body.AddForce(ballDirection * force, ForceMode2D.Impulse);
            force = 0;
            mouseEnd = Vector2.zero;
        }
        if (body.velocity.magnitude < 0.1)
        {
            body.velocity = Vector2.zero; //Stop the ball instead of waiting forever for it to slow down
        }
    }

    public void OnMouseDown()
    {
        mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseUp()
    {
        if (!ballStopped) return;
        mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("Mouse End: " + mouseEnd);
        force = Mathf.Clamp(Vector2.Distance(mouseStart, mouseEnd) * velocityScale, 0, 3);
        hit = true;
        GameEvents.current.BallHit();
    }
}
