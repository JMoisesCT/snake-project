using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    private List<Transform> _snakeParts;

    private void Awake()
    {
        _snakeParts = new List<Transform>();
        _snakeParts.Add(GameObject.FindGameObjectWithTag(NamesManager.TAG_NAME_HEAD).transform);
        GameObject[] bodyParts = GameObject.FindGameObjectsWithTag(NamesManager.TAG_NAME_BODY);
        for(int i = 0; i < bodyParts.Length; ++i)
        {
            _snakeParts.Add(bodyParts[i].transform);
        }
    }

    public void MoveSnake(Vector2 movement)
    {
        for (int i = 0; i < _snakeParts.Count; ++i)
        {
            _snakeParts[i].position += (Vector3)movement * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS;
        }
    }
}
