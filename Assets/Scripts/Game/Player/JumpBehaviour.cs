using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class JumpBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collider;
    private Animator anime;
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
        this.anime = GetComponent<Animator>();
        maxDistancia = collider.bounds.extents.y + distanciaDoChao.Value;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = NoChao();
        anime.SetBool("isGround", isGround);
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            rb.AddForce(this.force.Value,ForceMode.Impulse);
            anime.SetTrigger("jump");
        }
    }

    private bool NoChao()
    {
        return Physics.Raycast(transform.position, -Vector3.up, maxDistancia);
    }

}
