using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoCollider : MonoBehaviour, IPlayerObstaculo, IDestroy
{
    [SerializeField]
    private string poolTag;
    [SerializeField]
    private GameEvent gameOverEvent;
    [SerializeField]
    private BooleanReference isRunning;
    public void Destroy()
    {
        ObjectPooler.Instance.ReturnObjectToPool(poolTag, this.gameObject);
        isRunning.Value = false;
    }

    public void TriggerPlayer()
    {
        gameOverEvent.Raise();
    }
}
