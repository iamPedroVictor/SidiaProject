using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum INPUT_TYPE
{
    Human,
    IA
}

public class SaveInput : MonoBehaviour
{
    public InputType humanInput;
    public InputType iaInput;
    public InputLoad inputLoad;
    public UnityEvent loadSceneEvent;

    public void SaveInputType(int inputType)
    {
        INPUT_TYPE input = (INPUT_TYPE)inputType;
        if(input == INPUT_TYPE.Human)
        {
            inputLoad.inputChoise = humanInput;
        }else{
            inputLoad.inputChoise = iaInput;
        }
        loadSceneEvent?.Invoke();
    }

}
