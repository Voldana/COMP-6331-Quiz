using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float timeScale = 1;
    [Inject] private SignalBus signalBus;
    
    
}