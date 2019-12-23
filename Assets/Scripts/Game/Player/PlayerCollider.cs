using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu: " + collision.gameObject.name);
        IPlayerObstaculo obstaculo = collision.gameObject.GetComponent<IPlayerObstaculo>();
        obstaculo?.TriggerPlayer();
    }


}

