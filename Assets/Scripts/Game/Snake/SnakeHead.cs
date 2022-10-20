using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [Header("Sender Events")]
    [SerializeField] private VoidEventChannelSO _eventCollectFood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(NamesManager.TAG_NAME_FOOD))
        {
            _eventCollectFood.RaiseEvent();
            // Relocate food randomly inside the game field.
            int randomX = Random.Range(ConstantsManager.MIN_X_LIMIT_GAME_GRID,
                ConstantsManager.MAX_X_LIMIT_GAME_GRID + 1);
            int randomY = Random.Range(ConstantsManager.MIN_Y_LIMIT_GAME_GRID, 
                ConstantsManager.MAX_Y_LIMIT_GAME_GRID + 1);
            collision.transform.position = new Vector3(randomX * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS,
                randomY * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS, 0f);
        }
    }
}
