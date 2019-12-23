using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        IPlayerObstaculo obstaculo = collision.gameObject.GetComponent<IPlayerObstaculo>();
        obstaculo?.TriggerPlayer();
    }

    public void Teste(string msg) {
        Debug.Log(msg);
        Time.timeScale = 0;
    }
}

