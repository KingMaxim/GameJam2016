using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void EventListener(IEvent args);

public class EventManager
{
    public static EventManager Instance = new EventManager();

    private Dictionary<string, List<EventListener>> listeners = new Dictionary<string, List<EventListener>>();

    private EventManager()
    {}
	
    public void AddListener(string eventName, EventListener listener)
    {
        List<EventListener> currentListeners = listeners[eventName];
        
        if(currentListeners == null)
        {
            currentListeners = new List<EventListener>();
        }

        currentListeners.Add(listener);
    }

    public void RemoveListener(string eventName, EventListener listener)
    {
        List<EventListener> currentListeners = listeners[eventName];

        if(currentListeners == null)
        {
            return;
        }

        currentListeners.Remove(listener);
    }

    public void FireEvent(string EventName, IEvent args)
    {
        List<EventListener> currentListeners = listeners[EventName];

        if(currentListeners == null)
        {
            return;
        }

        foreach (EventListener item in currentListeners)
        {
            item(args);
        }
    }
}
