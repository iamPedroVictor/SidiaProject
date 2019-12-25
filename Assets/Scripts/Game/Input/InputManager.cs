using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private InputType input;
    [SerializeField]
    private InputLoad load;
    [SerializeField]
    private GameObject viewGO;
    [SerializeField]
    private Transform player;
    private void Awake()
    {
        input = load.inputChoise;
        string typeOfInput = input.GetType().ToString();
        if (typeOfInput.Equals("IAInput"))
        {
            IABuild();
        }
        else
        {
            PlayerBuild();
        }
    }
    private void PlayerBuild()
    {
        viewGO.SetActive(false);
    }

    private void IABuild()
    {
        IAInput ia = (IAInput)input;
        ia?.Init(player);
        viewGO.SetActive(true);
    }

    private void Update()
    {
        input.InputAction();
    }

}
