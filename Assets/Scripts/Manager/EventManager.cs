using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager
{
    private static Hashtable eventHashtable = new Hashtable();

    // Action 타입
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
    public static void AddEvent_Action_Action(string eventName, Action<Action> addEvent)
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
    public static void AddEvent_Action_GameObject(string eventName, Action<GameObject> addEvent)
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
    public static void AddEvent_Action_Int(string eventName, Action<int> addEvent)
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
    public static void AddEvent_Action_Float_Float(string eventName, Action<float, float> addEvent)
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
    public static void AddEvent_Action_Bool(string eventName, Action<bool> addEvent)
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
    public static void AddEvent_Action_Vector3(string eventName, Action<Vector3> addEvent)
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

    // Function 타입
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
    public static void AddEvent_Function(string eventName, Action<Func<bool>> addEvent)
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
    public static void TriggerEvent_Action(string eventName, bool param)
    {
        Action<bool> action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action<bool>)
            {
                action = (Action<bool>)eventHashtable[eventName]; // 언박싱
                action?.Invoke(param);
            }
        }
    }
    public static void TriggerEvent_Action(string eventName, int param)
    {
        Action<int> action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action<int>)
            {
                action = (Action<int>)eventHashtable[eventName]; // 언박싱
                action?.Invoke(param);
            }
        }
    }
    public static void TriggerEvent_Action(string eventName, Func<bool> param)
    {
        Action<Func<bool>> action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action<Func<bool>>)
            {
                action = (Action<Func<bool>>)eventHashtable[eventName]; // 언박싱
                action?.Invoke(param);
            }
        }
    }
    public static void TriggerEvent_Action(string eventName, Vector3 param)
    {
        Action<Vector3> action;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Action<Vector3>)
            {
                action = (Action<Vector3>)eventHashtable[eventName]; // 언박싱
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
    public static bool TriggerEvent_Boolean(string eventName)
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

    // Vecter2 타입
    public static Vector2 TriggerEvent_Vector2(string eventName)
    {
        Func<Vector2> function;

        if (eventHashtable.ContainsKey(eventName))
        {
            if (eventHashtable[eventName] is Func<Vector2>)
            {
                function = (Func<Vector2>)eventHashtable[eventName];
                return function.Invoke();
            }
        }

        return new Vector2(0, 0);
    }
}
