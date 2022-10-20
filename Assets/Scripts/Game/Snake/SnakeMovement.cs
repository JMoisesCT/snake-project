using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float _tickTimeMovement;

    private SnakeController _snakeController;

    private float _timer;
    private Vector2 _movement;
    private Vector2 _lastMovement;

    public void Initialize(SnakeController snakeController)
    {
        _snakeController = snakeController;

        _timer = _tickTimeMovement;
        _movement = new Vector2(1f, 0f); // By default the snake will move to the right.
        _lastMovement = _movement;

        _snakeController.InitializeMoves(_movement);
    }

    // Update is called once per frame
    public void DoUpdate()
    {
        DetectInput();

        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            float timeOffset = _timer; // To be more precise with the ticks
            _timer = _tickTimeMovement - timeOffset;
            _lastMovement = _movement;
            _snakeController.MoveSnake(_movement);
        }
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_lastMovement.x != 1)
            {
                _movement = new Vector2(-1f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_lastMovement.x != -1)
            {
                _movement = new Vector2(1f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (_lastMovement.y != 1)
            {
                _movement = new Vector2(0f, -1f);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_lastMovement.y != -1)
            {
                _movement = new Vector2(0f, 1f);
            }
        }
    }
}
