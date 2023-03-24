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
    private bool canHit = false;
    private Vector3 ballDirection;
    private Vector3 mouseStart;
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
        }
    }

    private void FixedUpdate()
    {
        if (canHit)
        {
            canHit = false;
            ballStopped = false;
            ballDirection = mouseStart - mouseEnd;

            body.AddForce(ballDirection * force, ForceMode2D.Impulse);
            force = 0;
            mouseStart = mouseEnd = Vector2.zero;
        } else
        {
            canHit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hole")
        {
            //Trigger level being completed
        }
    }

    public void OnMouseDown()
    {
        if (!ballStopped) return; //Can't click on the ball if it's moving!
        mouseStart = FindBallClick();
    }

    public void OnMouseUp()
    {
        if (!ballStopped) return;
        mouseEnd = FindBallRelease();
        force = Mathf.Clamp(Vector2.Distance(mouseEnd, mouseStart) * velocityScale, 0, Mathf.Infinity);
    }

    Vector2 FindBallClick()
    {
        Vector2 pos = Vector2.zero;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            pos = hit.point;
        }
        Debug.Log("Found Click at " + pos);
        return pos;
    }

    Vector2 FindBallRelease()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
   
    /*void OnMouseDrag()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 ball = transform.position;

        expectedVelocity = Vector2.Distance(mousePos, ball) * velocityScale;

        //Debug.Log(mousePos.x);
        //Debug.Log(mousePos.y);
        //Debug.Log(ball);
        Debug.Log(expectedVelocity);
    }*/
}
