using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSpawner : MonoBehaviour
{
    
    [SerializeField]
    private FloatReference TempoMinimo;
    [SerializeField]
    private FloatReference TempoMaximo;
    [SerializeField]
    private Transform InicioTransform;
    [SerializeField]
    private BooleanReference isRunning;

    private float tempoSpawn = 2f;

    private void Update()
    {
        if (!isRunning.Value)
        {
            return;
        }
        if(Time.timeSinceLevelLoad > tempoSpawn)
        {
            float proximo = Random.Range(TempoMinimo.Value, TempoMaximo.Value);
            tempoSpawn += proximo;
            
            ObjectPooler.Instance.SpawnFromPool("Box", InicioTransform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }


}
