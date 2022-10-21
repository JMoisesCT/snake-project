using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [Header("Sender Events")]
    [SerializeField] private VoidEventChannelSO _eventCollectFood;
    [SerializeField] private VoidEventChannelSO _eventSnakeGameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(NamesManager.TAG_NAME_FOOD))
        {
            _eventCollectFood.RaiseEvent();
            SnakeFood food = collision.GetComponent<SnakeFood>();
            if (food == null)
            {
                Debug.LogError($"SnakeHead.OnTriggerEnter2D food is null");
                return;
            }
            food.RelocateInNewPosition();
        }

        // End Over Collision
        if (collision.CompareTag(NamesManager.TAG_NAME_LIMIT) ||
            collision.CompareTag(NamesManager.TAG_NAME_BODY))
        {
            _eventSnakeGameOver.RaiseEvent();
        }
    }
}
