using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private float _tickTimeMovement;

    private Vector2 _movement;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _timer = _tickTimeMovement;
        _movement = new Vector2(1f, 0f); // By default the snake will move to the right.
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            float timeOffset = _timer; // To be more precise with the ticks
            _timer = _tickTimeMovement - timeOffset;
        }
    }
}
