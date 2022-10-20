using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabSnakeBody;

    [Header("Listener Events")]
    [SerializeField] private VoidEventChannelSO _eventCollectFood;

    private SnakeMovement _snakeMovement;

    private List<Transform> _snakeParts;
    private List<Vector2> _snakeNextMove;

    private void Awake()
    {
        _snakeMovement = GetComponent<SnakeMovement>();

        _snakeParts = new List<Transform>();
        _snakeParts.Add(GameObject.FindGameObjectWithTag(NamesManager.TAG_NAME_HEAD).transform);
        GameObject[] bodyParts = GameObject.FindGameObjectsWithTag(NamesManager.TAG_NAME_BODY);
        for(int i = 0; i < bodyParts.Length; ++i)
        {
            _snakeParts.Add(bodyParts[i].transform);
        }

        _snakeNextMove = new List<Vector2>();

        _snakeMovement.Initialize(this);
    }

    private void Start()
    {
        _eventCollectFood.onEventRaised += IncreaseSizeSnake;
    }

    private void OnDestroy()
    {
        _eventCollectFood.onEventRaised -= IncreaseSizeSnake;
    }

    public void InitializeMoves(Vector2 movement)
    {
        for(int i = 0; i < _snakeParts.Count; ++i)
        {
            _snakeNextMove.Add(movement);
        }
    }

    private void Update()
    {
        _snakeMovement.DoUpdate();
    }

    public void MoveSnake(Vector2 movement)
    {
        // Update all movements for the snake body.
        for(int i = _snakeNextMove.Count - 1; i > 0; --i)
        {
            _snakeNextMove[i] = _snakeNextMove[i - 1];
        }
        // Head of the snake should have the latest movement made by the player.
        _snakeNextMove[0] = movement;

        for (int i = 0; i < _snakeParts.Count; ++i)
        {
            _snakeParts[i].position += (Vector3)_snakeNextMove[i] * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS;
        }
    }

    private void IncreaseSizeSnake()
    {
        GameObject newBody = Instantiate(_prefabSnakeBody, transform);
        // New body is placed before the last snake body.
        Vector2 lastBodyMove = _snakeNextMove[_snakeNextMove.Count - 1];
        Vector3 lastBodyPosition = _snakeParts[_snakeParts.Count - 1].position;
        float newPosX = lastBodyPosition.x - lastBodyMove.x * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS;
        float newPosY = lastBodyPosition.y - lastBodyMove.y * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS;
        Vector3 newPositionBody = new Vector3(newPosX, newPosY, 0f);
        newBody.transform.position = newPositionBody;
        _snakeParts.Add(newBody.transform);
        _snakeNextMove.Add(lastBodyMove);
    }
}
