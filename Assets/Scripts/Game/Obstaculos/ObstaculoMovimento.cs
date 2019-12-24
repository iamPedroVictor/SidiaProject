using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ObstaculoMovimento : MonoBehaviour
{
    [SerializeField]
    private FloatReference velocidade;
    [SerializeField]
    private BooleanReference isRunning;

    private void FixedUpdate()
    {
        if (!isRunning.Value)
        {
            return;
        }
        transform.position = transform.position 
            + new Vector3(-velocidade.Value * Time.fixedDeltaTime, 0, 0);
    }


}
