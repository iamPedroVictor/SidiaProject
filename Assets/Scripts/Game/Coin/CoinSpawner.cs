using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private IntReference TempoDeJogo;
    [SerializeField]
    private Transform InicioTransform;
    [SerializeField]
    private BooleanReference isRunning;
    [SerializeField]
    [Range(0, 1)]
    private float porcentage;
    [SerializeField]
    private float proximoTempo = 1.3f;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private StringReference CoinTag;
    [SerializeField]
    private IntReference size;
    private float tempo = 3f;
    [SerializeField]
    private BooleanReference first;
    [SerializeField]
    private float offsetY;

    private void Start()
    {
        ObjectPooler.Instance.NewPool(coinPrefab, CoinTag, size);
        first.Value = true;
    }

    private void Update()
    {
        if (isRunning.Value)
        {
            if (TempoDeJogo.Value > tempo)
            {
                float chance = Random.Range(0f, 1f);
                if(chance < porcentage)
                {
                    tempo += proximoTempo;
                    GameObject coin = ObjectPooler.Instance.SpawnFromPool(CoinTag.Value, InicioTransform.position, Quaternion.identity);
                    if (first.Value)
                    {
                         BoardFollowCoin(coin);
                    }
                }
            }
        }
    }

    private void BoardFollowCoin(GameObject boxObject)
    {
        ObstaculoBoard board = boxObject.AddComponent<ObstaculoBoard>(); 
        board.BoardTransform = GameObject.Find("MoedaBoard").GetComponent<RectTransform>();
        board.Obstaculo = boxObject.transform;
        board.OffsetY = offsetY;
        first.Value = false;
    }

}
