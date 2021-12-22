using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private int points;

    private SnakeMovement movement;
    private List<OnKilled> onKilledSubs = new List<OnKilled>();
    private List<OnPointsChanged> onPointsChangedSubs = new List<OnPointsChanged>();

    public int Points
    {
        get
        {
            return points;
        }
        set
        {
            int prevValue = points;
            points = value;

            onPointsChangedSubs.ForEach(s => s(prevValue, value));
        }
    }

    private void Start()
    {
        movement = GetComponent<SnakeMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            movement.Direction = Direction.Left;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            movement.Direction = Direction.Right;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            movement.Direction = Direction.Up;
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            movement.Direction = Direction.Down;
    }


    public delegate void OnKilled();

    public event OnKilled onKilled
    {
        add => onKilledSubs.Add(value);
        remove => onKilledSubs.Remove(value);
    }


    public delegate void OnPointsChanged(int previousValue, int nextValue);

    public event OnPointsChanged onPointsChanged
    {
        add => onPointsChangedSubs.Add(value);
        remove => onPointsChangedSubs.Remove(value);
    }

    public void AddPoints(int pointsToAdd)
    {
        Points += pointsToAdd;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Kill();
    }

    public void Kill()
    {
        ScoreManager.Instance.SaveHighScore(Points);
        onKilledSubs.ForEach(s => s());
        Destroy(this.gameObject);
    }
}
