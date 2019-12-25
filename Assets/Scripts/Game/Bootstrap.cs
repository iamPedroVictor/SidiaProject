using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    private BooleanReference isRunning;
    [SerializeField]
    private FloatReference velocidade;

    private void Awake()
    {
        velocidade.Value = 4;
        isRunning.Value = true;
    }

}
