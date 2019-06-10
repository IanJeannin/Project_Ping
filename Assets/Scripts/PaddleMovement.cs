using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [Tooltip("Transform of the object.")]
    [SerializeField]
    private Transform paddle;
    [Tooltip("Transform of the circle object rotates on.")]
    [SerializeField]
    private Transform track;

    float angle = 0;
    float speed = (2 * Mathf.PI) / 5; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    float radius = 5;
    private float paddleXPos;
    private float paddleYPos;
    private Vector2 directionOfRotation;

    void Update()
    {
        if(Input.GetAxis("Clockwise")>0)
        {
            MoveClockwise();
        }
        else if(Input.GetAxis("CounterClockwise")>0)
        {
            MoveCounterClockwise();
        }
        transform.up = track.position - paddle.position; //Sets paddle rotation to face center of circle
    }

    public void MoveClockwise()
    {
        angle -= speed * Time.deltaTime; 
        paddleXPos = Mathf.Cos(angle) * radius;
        paddleYPos = Mathf.Sin(angle) * radius;
        paddle.position = new Vector3(paddleXPos, paddleYPos);
    }

    public void MoveCounterClockwise()
    {
        angle += speed * Time.deltaTime;
        paddleXPos = Mathf.Cos(angle) * radius;
        paddleYPos = Mathf.Sin(angle) * radius;
        paddle.position = new Vector3(paddleXPos, paddleYPos);
    }
    
}
