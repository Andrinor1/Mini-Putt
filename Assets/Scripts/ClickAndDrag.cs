using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{

    public float velocityScale = 1;

    private Rigidbody2D body;
    private float force;
    private bool ballStopped = true;
    private bool hit = false;
    private Vector3 ballDirection;
    private Vector3 mouseEnd;

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
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
            ballDirection = transform.position - mouseEnd;

            body.AddForce(ballDirection * force, ForceMode2D.Impulse);
            force = 0;
            mouseEnd = Vector2.zero;
        }
        if (body.velocity.magnitude < 0.1)
        {
            body.velocity = Vector2.zero; //Stop the ball instead of waiting forever for it to slow down
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hole")
        {
            //Trigger level being completed
        }
    }

    public void OnMouseUp()
    {
        if (!ballStopped) return;
        mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("Mouse End: " + mouseEnd);
        force = Mathf.Clamp(Vector2.Distance(mouseEnd, transform.position) * velocityScale, 0, 3);
        hit = true;
    }
    
}
