using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowDrag : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector2 startPoint;
    Vector2 currentPoint;
    Rigidbody2D playerBody;
    ClickAndDrag script;
    void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>();
        script = player.GetComponent<ClickAndDrag>();
    }
    private void OnMouseDown()
    {
        //if (script.ballStopped)
        //{
        //    startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        startPoint = playerBody.transform.position;
    }
    private void Update()
    {
        Debug.Log(startPoint);
        if (script.ballStopped && Input.GetMouseButton(0))
        {
            currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var dir = startPoint - currentPoint;
            //var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.Rotate(0, 0, 180);
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
