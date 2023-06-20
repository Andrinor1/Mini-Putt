using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private float enterSpeed = 1.2f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject ball = collision.gameObject;
        Vector2 ballVelocity = ball.GetComponent<Rigidbody2D>().velocity;
        float distance = Vector2.Distance(transform.position, ball.transform.position);
        if (ballVelocity.magnitude < enterSpeed && distance < 0.3)
        {
            ball.SetActive(false);
            ScoreKeeper.instance.endLevel();
        }
    }
}
