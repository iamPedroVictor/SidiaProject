using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [SerializeField]
    private Vector3Reference force;
    [SerializeField]
    private string explosionTag;
    private Rigidbody rb;
    private float timeToDisable;
    private bool die;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void DestroyPlayer()
    {
        ObjectPooler.Instance.SpawnFromPool(explosionTag, transform.position, transform.rotation);
        die = true;
        timeToDisable = Time.timeSinceLevelLoad + 2f;
        rb.AddForce(force.Value, ForceMode.Impulse);
        
    }

    private void Update()
    {
        if(Time.timeSinceLevelLoad > timeToDisable && die)
        {
            gameObject.SetActive(false);
        }
    }

}
