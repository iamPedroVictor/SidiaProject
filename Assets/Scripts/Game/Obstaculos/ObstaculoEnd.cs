using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObstaculoEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDestroy destroyGameObject = other.GetComponent<IDestroy>();
        destroyGameObject?.Destroy();
    }
}
