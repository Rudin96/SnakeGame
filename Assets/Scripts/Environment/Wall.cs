using UnityEngine;
using System;


public enum Orientation
{
    Horizontal,
    Vertical
}
public class Wall : MonoBehaviour
{
    public Orientation Orientation;
    private void OnValidate()
    {
        switch (Orientation)
        {
            case Orientation.Horizontal:
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;
            case Orientation.Vertical:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;

            throw new IndexOutOfRangeException("Invalid");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        if(collision.gameObject.CompareTag("Player"))
        {
            SnakeController snake = collision.gameObject.GetComponent<SnakeController>();
            snake.Kill();
        }
    }
}
