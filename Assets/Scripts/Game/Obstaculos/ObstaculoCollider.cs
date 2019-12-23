using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoCollider : MonoBehaviour, IPlayerObstaculo, IDestroy
{
    [SerializeField]
    private string poolTag;
    [SerializeField]
    private GameEvent gameOverEvent;

    public void Destroy()
    {
        ObjectPooler.Instance.ReturnObjectToPool(poolTag, this.gameObject);
    }

    public void TriggerPlayer()
    {
        gameOverEvent.Raise();
    }
}
