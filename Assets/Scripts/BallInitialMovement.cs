using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInitialMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerOnePaddle;
    //Add Player Two later
    [Tooltip("Initial time at round start before ball begins movement")]
    [SerializeField]
    private float startingPause;
    [Tooltip("Transform of the ball.")]
    [SerializeField]
    private Transform ballTransform;
    [Tooltip("Rigidbody2D of the ball.")]
    [SerializeField]
    private Rigidbody2D ballRigidbody;
    [Tooltip("The number of seconds before the ball becomes faster.")]
    [SerializeField]
    private float timeBetweenSpeedIncrease;
    [SerializeField]
    private float speed=1;
    [SerializeField]
    private float maxSpeed;

    private void Start()
    {
        StartCoroutine("InitialMovementOfBall");
        StartCoroutine("IncreaseSpeedOfBall");
    }

    private IEnumerator InitialMovementOfBall()
    {
        yield return new WaitForSeconds(startingPause);
        MoveBall();
    }

    public void MoveBall()
    {
        //ballTransform.forward = playerOnePaddle.position - ballTransform.position;
        //ballTransform.Translate(ballTransform.right * .1f * Time.deltaTime);
        Vector2 vector = new Vector2(100, 0);
        ballRigidbody.AddForce(vector*speed);
        //ballRigidbody.AddForce(Vector2.right,ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 vel;
            Debug.Log("paddle x= " + collision.collider.attachedRigidbody.velocity.x);
            Debug.Log("paddle y= " + collision.collider.attachedRigidbody.velocity.y);
            vel.x = ballRigidbody.velocity.x;
            Debug.Log("Ball x= " + vel.x);
            vel.y = (ballRigidbody.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            Debug.Log("Ball y= " + vel.y);
            ballRigidbody.velocity = vel;
        }
    }

    /// <summary>
    /// Every timeBetweenSpeedIncrease number of seconds, increase speed of ball. 
    /// </summary>
    private IEnumerator IncreaseSpeedOfBall()
    {
        while (speed <= maxSpeed)
        {
            yield return new WaitForSeconds(timeBetweenSpeedIncrease);
            speed += 0.2f;
            ballRigidbody.velocity = ballRigidbody.velocity * speed;
        }
    }

    
}
