using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private float enterSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject ball = collision.gameObject;
        Vector2 ballVelocity = ball.GetComponent<Rigidbody2D>().velocity;
        float distance = Vector2.Distance(transform.position, ball.transform.position);
        Debug.Log(distance);
        if (ballVelocity.magnitude < enterSpeed && distance < 0.3)
        {
            Debug.Log("POINTS!");
            ball.SetActive(false);
        }
    }
}
