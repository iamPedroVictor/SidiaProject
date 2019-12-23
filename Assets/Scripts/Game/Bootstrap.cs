using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private BooleanReference isRunning;

    private void Awake()
    {
        isRunning.Value = true;
    }

}
