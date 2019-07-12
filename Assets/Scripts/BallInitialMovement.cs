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
    private float speed=1;
    [Tooltip("By how much the speed will increase at each increment.")]
    [SerializeField]
    private float speedIncrease = 0.2f;
    [SerializeField]
    private float maxSpeed=3;
    [Tooltip("How many bounces before the ball increases in speed.")]
    [SerializeField]
    private float bouncesBeforeSpeedIncrease=2 ;

    /// <summary>
    /// Counts how many bounces have passed;
    /// </summary>
    private float numberOfBounces = 0;

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
            numberOfBounces++;
            Vector2 vel;
            Debug.Log("paddle x= " + collision.collider.attachedRigidbody.velocity.x);
            Debug.Log("paddle y= " + collision.collider.attachedRigidbody.velocity.y);
            vel.x = ballRigidbody.velocity.x;
            Debug.Log("Ball x= " + vel.x);
            vel.y = (ballRigidbody.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            Debug.Log("Ball y= " + vel.y);
            if (numberOfBounces >= bouncesBeforeSpeedIncrease)
            {
                speed += speedIncrease;
                ballRigidbody.velocity = vel*speed;
                numberOfBounces = 0;
            }
            else
            {
                ballRigidbody.velocity = vel;
            }
        }
    }
    

    
}
