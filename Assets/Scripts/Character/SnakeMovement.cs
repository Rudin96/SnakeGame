using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class SnakeMovement : MonoBehaviour
{
    public float MovementSpeed = 1f;

    private void Start()
    {
        StartCoroutine(Move());
    }

    public void SetMovementSpeed(float newMovementSpeed)
    {
        MovementSpeed = newMovementSpeed;
    }

    public void Rotate(float degrees)
    {
        transform.Rotate(Vector3.forward, degrees);
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = transform.position + transform.up;
            yield return new WaitForSecondsRealtime(MovementSpeed);
        }
    }
}
