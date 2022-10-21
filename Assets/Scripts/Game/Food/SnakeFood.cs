using UnityEngine;

public class SnakeFood : MonoBehaviour
{
    public void RelocateInNewPosition()
    {
        bool lookingForNewPosition = true;
        int tries = 0;
        while (lookingForNewPosition)
        {
            // Relocate food randomly inside the game field.
            int randomX = Random.Range(ConstantsManager.MIN_X_LIMIT_GAME_GRID,
                ConstantsManager.MAX_X_LIMIT_GAME_GRID + 1);
            int randomY = Random.Range(ConstantsManager.MIN_Y_LIMIT_GAME_GRID,
                ConstantsManager.MAX_Y_LIMIT_GAME_GRID + 1);

            Vector3 pos = new Vector3(randomX * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS,
                randomY * ConstantsManager.DISTANCE_BETWEEN_SNAKE_PARTS, 0f);
            tries++;
            Debug.Log($"pos = {pos} tries = {tries}");

            if (Physics2D.CircleCast(pos, 0.1f, Vector2.zero).collider == null)
            {
                // If the position is free, let's assign it to the food.
                // It could be improved to be more precise saving somehow
                // all the unusable positions.
                transform.position = pos;
                lookingForNewPosition = false;
                tries = 0;
            }
        }
    }
}
