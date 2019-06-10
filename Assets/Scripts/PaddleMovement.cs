using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
   
    [SerializeField]
    private Transform paddle;
    [SerializeField]
    private Transform track;

    float angle = 1;
    float speed = (2 * Mathf.PI) / 5; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    float radius = 5;
    private float paddleXPos;
    private float paddleYPos;
    private Vector2 directionOfRotation;

    void Update()
    {
        angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        paddleXPos = Mathf.Cos(angle) * radius;
        paddleYPos = Mathf.Sin(angle) * radius;
        paddle.position = new Vector3(paddleXPos, paddleYPos);
        directionOfRotation = track.position - paddle.position;
        float rotationAngle = Mathf.Atan2(directionOfRotation.y, directionOfRotation.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    public void MoveClockwise()
    {

    }
    
}
