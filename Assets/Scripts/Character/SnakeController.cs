using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private SnakeMovement movement;

    public int Points;

    private void Start()
    {
        movement = GetComponent<SnakeMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            movement.Rotate(90f);
        if (Input.GetKeyDown(KeyCode.D))
            movement.Rotate(-90f);
        //if(Input.GetKeyDown (KeyCode.S))
        //    movement.Direction = Direction.Down;
        //if(Input.GetKeyDown (KeyCode.W))
        //    movement.Direction = Direction.Up;
    }

    public void AddPoints(int pointsToAdd)
    {
        Points += pointsToAdd;
    }

    public void Kill()
    {
        ScoreManager.SaveHighScore(Points);
        Destroy(gameObject);
    }
}
