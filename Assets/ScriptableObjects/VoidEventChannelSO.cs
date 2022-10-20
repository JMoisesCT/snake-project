using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName ="Events/Create Void Event")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction onEventRaised;

    public void RaiseEvent()
    {
        onEventRaised?.Invoke();
    }
}
