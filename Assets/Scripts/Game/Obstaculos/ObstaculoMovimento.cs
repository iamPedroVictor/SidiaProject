using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ObstaculoMovimento : MonoBehaviour
{
    [SerializeField]
    private FloatReference velocidade;    


    private void FixedUpdate()
    {
        transform.position = transform.position 
            + new Vector3(velocidade.Value * Time.fixedDeltaTime, 0, 0);
    }

}
