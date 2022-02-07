using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    private static Hashtable eventHashtable = new Hashtable();

    public static void AddEvent_Action(string eventName, Action addEvent)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable[eventName] = addEvent;
        }
        else
        {
            eventHashtable.Add(eventName, addEvent);
        }
    }
    public static void AddEvent_Action(string eventName, Action<GameObject> addEvent)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable[eventName] = addEvent;
        }
        else
        {
            eventHashtable.Add(eventName, addEvent);
        }
    }
    public static void AddEvent_Action(string eventName, Action<float, float> addEvent)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable[eventName] = addEvent;
        }
        else
        {
            eventHashtable.Add(eventName, addEvent);
        }
    }
    public static void AddEvent_Action(string eventName, Action<Action> addEvent)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable[eventName] = addEvent;
        }
        else
        {
            eventHashtable.Add(eventName, addEvent);
        }
    }
    public static void AddEvent_Function(string eventName, Func<bool, bool> addEvent)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable[eventName] = addEvent;
        }
        else
        {
            eventHashtable.Add(eventName, addEvent);
        }
    }
    public static void AddEvent_Function(string eventName, Func<bool> addEvent)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable[eventName] = addEvent;
        }
        else
        {
            eventHashtable.Add(eventName, addEvent);
        }
    }

    public static void RemoveEvent(string eventName)
    {
        if (eventHashtable.ContainsKey(eventName))
        {
            eventHashtable.Remove(eventName);
        }
        else
        {
            Debug.Log("제거할 함수가 없습니다.");
        }
    }

    // void 타입
    public static void TriggerEvent_Action(string eventName)
    {
        Action action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action)
            {
                action = (Action)eventHashtable[eventName];
                action?.Invoke();
            }
        }
    }
    public static void TriggerEvent_Action(string eventName, GameObject param)
    {
        Action<GameObject> action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action<GameObject>)
            {
                action = (Action<GameObject>)eventHashtable[eventName]; // 언박싱
                action?.Invoke(param);
            }
        }
    }
    public static void TriggerEvent_Action(string eventName, float param1, float param2)
    {
        Action<float, float> action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action<float, float>)
            {
                action = (Action<float, float>)eventHashtable[eventName]; // 언박싱
                action?.Invoke(param1, param2);
            }
        }
    }

    // bool 타입
    public static bool TriggerEvent_Function(string eventName)
    {
        Func<bool> function;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Func<bool>)
            {
                function = (Func<bool>)eventHashtable[eventName];
                return function.Invoke();
            }
        }

        return false;
    }
}
