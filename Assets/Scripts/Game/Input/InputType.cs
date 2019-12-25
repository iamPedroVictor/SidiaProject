using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputType : ScriptableObject
{
    [SerializeField]
    protected GameEvent inputEvent;

    public abstract void InputAction();
}
