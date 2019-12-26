using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IPlayerObstaculo, IDestroy
{
    [SerializeField]
    private GameEvent moedaEvento;
    [SerializeField]
    private StringReference moedaTag;
    [SerializeField]
    private GameEvent MoedaBoard;

    public void Destroy()
    {
        RetornarMoedaParaPool();

    }

    public void TriggerPlayer()
    {
        moedaEvento.Raise();
        RetornarMoedaParaPool();
    }

    private void RetornarMoedaParaPool()
    {
        MoedaBoard.Raise();
        ObjectPooler.Instance.ReturnObjectToPool(moedaTag.Value, gameObject);
    }
}
