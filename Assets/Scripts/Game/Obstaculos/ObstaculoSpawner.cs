using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstaculoSpawner : MonoBehaviour
{
    
    [SerializeField]
    private FloatReference TempoDeSpawn;
    [SerializeField]
    private Transform InicioTransform;
    [SerializeField]
    private BooleanReference isRunning;
    [SerializeField]
    [Range(0,1)]
    private float porcentage;
    [SerializeField]
    private StringReference Tag1, Tag2;
    private float tempoSpawn = 2f;
    [SerializeField]
    private BooleanReference first;
    [SerializeField]
    private float offsetY;

    private void Awake()
    {
        first.Value = true;
    }
    private void Update()
    {
        if (!isRunning.Value)
        {
            return;
        }
        
        if(Time.timeSinceLevelLoad > tempoSpawn)
        {
            float proximo = TempoDeSpawn.Value;
            tempoSpawn += proximo;
            string tag = GetTag();
            
            GameObject obs = ObjectPooler.Instance.SpawnFromPool(tag, InicioTransform.position, Quaternion.identity);
            if (first.Value)
            {
                BoardFollowBox(obs);             
            }
        }
    }
    
    private void BoardFollowBox(GameObject boxObject)
    {
        ObstaculoBoard board = boxObject.AddComponent<ObstaculoBoard>();
        board.BoardTransform = GameObject.Find("Board").GetComponent<RectTransform>();
        board.Obstaculo = boxObject.transform;
        board.OffsetY = offsetY;
        first.Value = false;
    }

    private string GetTag()
    {
        float number = Random.Range(0, 1f);
        if(number <= porcentage)
        {
            return Tag1.Value;
        }
        return Tag2.Value;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }


}
