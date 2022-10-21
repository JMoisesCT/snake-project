using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Listener Events")]
    [SerializeField] private VoidEventChannelSO _eventSnakeGameOver;

    [Header("Screens Reference")]
    [SerializeField] private GameObject _canvasGameOver;

    private void Start()
    {
        _eventSnakeGameOver.onEventRaised += ShowGameOverScreen;
    }

    private void OnDestroy()
    {
        _eventSnakeGameOver.onEventRaised -= ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        _canvasGameOver.SetActive(true);
    }
}
