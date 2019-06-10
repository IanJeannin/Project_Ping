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

    private void Start()
    {
        StartCoroutine("InitialMovementOfBall");
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
        Vector2 vector = new Vector2(1, 0);
        ballRigidbody.AddForce(Vector2.right,ForceMode2D.Impulse);
    }

}
