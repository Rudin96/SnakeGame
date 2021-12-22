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
    public Direction Direction = Direction.Up;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            transform.position = transform.position + (Vector3)CalculateDir();
            yield return new WaitForSecondsRealtime(MovementSpeed);
        }
    }

    private Vector2 CalculateDir()
    {
        switch (Direction)
        {
            case Direction.Up:
                return Vector2.up;
            case Direction.Down:
                return Vector2.down;
            case Direction.Left:
                return Vector2.left;
            case Direction.Right:
                return Vector2.right;
            default:
                return Vector2.zero;
        }
    }

    public void SetMovementSpeed(float newMovementSpeed)
    {
        MovementSpeed = newMovementSpeed;
    }

    public void Rotate(float degrees)
    {
        transform.Rotate(Vector3.forward, degrees);
    }

}
