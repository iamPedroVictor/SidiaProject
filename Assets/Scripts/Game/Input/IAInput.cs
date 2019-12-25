using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Input/IA")]
public class IAInput : InputType
{
    [SerializeField]
    private TransformListReference obstaculos;
    [SerializeField]
    private FloatReference distanciaMinima;
    [SerializeField]
    private BooleanReference isGround;
    private Transform transform;
    [SerializeField]
    private float jumpIntervalTime = 0.9f;
    [SerializeField]
    private IntReference tempo;
    private float proximoPulo = 0;
    
    public void Init(Transform tf)
    {
        transform = tf;
        proximoPulo = 0;
    }

    public override void InputAction()
    {
        if (obstaculos.Value.Count > 0)
        {
            Transform obstaculo = obstaculos.Value[0];
            float distanciaDoObstaculo = obstaculo.position.x - transform.position.x;
            bool isTimeToJump = tempo.Value >= proximoPulo;
            bool distanciaParaPular = distanciaDoObstaculo <= distanciaMinima.Value;
            
            if (distanciaParaPular && isGround.Value && isTimeToJump)
            {
                proximoPulo = tempo.Value + jumpIntervalTime;
                inputEvent.Raise();
            }
        }
    }
}
