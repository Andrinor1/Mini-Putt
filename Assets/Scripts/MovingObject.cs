using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;

    private Vector2 startPos;

    [SerializeField] private Transform targetPoint;
    private Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        targetPos = targetPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
        if (Vector2.Distance(transform.position, targetPos) < 0.01f)
        {
            swap();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        Rigidbody2D rbo = other.GetComponent<Rigidbody2D>();
        if (rbo.velocity == Vector2.zero)
        {
            swap();

        }
    }

    void swap()
    {
        if (targetPos == (Vector2)targetPoint.position) targetPos = startPos;
        else targetPos = targetPoint.position;
    }
}
