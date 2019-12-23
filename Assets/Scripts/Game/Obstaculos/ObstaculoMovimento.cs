using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class ObstaculoMovimento : MonoBehaviour, IPoolObject
{
    [SerializeField]
    private IntReference velocidadeMinima;
    [SerializeField]
    private IntReference velocidadeMaxima;
    [SerializeField]
    private BooleanReference isRunning;
    private int velocidade;

    public void OnSpawn()
    {
        velocidade = getVelocidadeRandomica();
    }

    private void FixedUpdate()
    {
        if (!isRunning.Value)
        {
            return;
        }
        transform.position = transform.position 
            + new Vector3(velocidade * Time.fixedDeltaTime, 0, 0);
    }

    private int getVelocidadeRandomica() {
        return Random.Range(velocidadeMinima.Value, velocidadeMaxima.Value);
    }

}
