using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class JumpBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    [SerializeField]
    private Vector3Reference force;
    [SerializeField]
    private FloatReference distanciaDoChao;
    private float maxDistancia;
    private bool isGround;


    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
        this.collider = GetComponent<Collider>();
        maxDistancia = collider.bounds.extents.y + distanciaDoChao.Value;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = NoChao();
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            rb.AddForce(this.force.Value,ForceMode.Impulse);
        }
    }

    private bool NoChao()
    {
        return Physics.Raycast(transform.position, -Vector3.up, maxDistancia);
    }

}
