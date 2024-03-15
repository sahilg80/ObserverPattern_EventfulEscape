using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController
{
    public event Action BaseAction;
    public void AddListener(Action action)
    {
        BaseAction += action;
    }

    public void RemoveListener(Action action)
    {
        BaseAction -= action;
    }

    public void InvokeEvent()
    {
        BaseAction?.Invoke();
    }
}
