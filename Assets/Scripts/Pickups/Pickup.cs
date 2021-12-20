using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    None,
    Speed,
    Points
}

public class Pickup : MonoBehaviour
{
    public PickupType Type;

    public int PointsToAdd = 10;
    public float MovementSpeedModifier = .85f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;

        if (!collision.gameObject.CompareTag("Player")) return;

        switch (Type)
        {
            case PickupType.None:
                break;
            case PickupType.Speed:
                SnakeMovement snakeMovement = collision.gameObject?.GetComponent<SnakeMovement>();
                snakeMovement.SetMovementSpeed(snakeMovement.MovementSpeed * MovementSpeedModifier);
                break;
            case PickupType.Points:
                SnakeController snakeController = collision.gameObject?.GetComponent<SnakeController>();
                snakeController.AddPoints(PointsToAdd);
                break;
        }
    }
}
