using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoCollider : MonoBehaviour, IPlayerObstaculo, IDestroy
{
    [SerializeField]
    private StringReference poolTag;
    [SerializeField]
    private GameEvent gameOverEvent;
    [SerializeField]
    private BooleanReference isRunning;
    [SerializeField]
    private GameEvent BoardRender;

    public void Destroy()
    {
        ObjectPooler.Instance.ReturnObjectToPool(poolTag.Value, this.gameObject);
        BoardRender.Raise();
    }

    public void TriggerPlayer()
    {
        gameOverEvent.Raise();
        BoardRender.Raise();
    }
}
