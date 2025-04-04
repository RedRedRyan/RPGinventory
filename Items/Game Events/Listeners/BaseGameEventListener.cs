using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using Unity.VisualScripting;

namespace RaveTown.Events
{
public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
 IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
 {
    [SerializeField] private E gameEvent;
    public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }
    [SerializeField] private UER unityEventResponse;

    private void OnEnable()
    {
        if(gameEvent == null){return;}
        GameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        if(gameEvent == null){return;}
        GameEvent.UnregisterListener(this);
    }
    public void OnEventRaised(T item)
    {
        unityEventResponse.Invoke(item);
    }
 }
}
