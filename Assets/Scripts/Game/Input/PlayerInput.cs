using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Input/Mobile")]
public class PlayerInput : InputType
{
    public override void InputAction()
    {
        if (Input.GetMouseButtonUp(0))
        {
            inputEvent.Raise();
        }
    }
}
