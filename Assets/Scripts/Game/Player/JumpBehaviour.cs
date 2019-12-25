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
    [SerializeField]
    private BooleanReference isGround;
    [SerializeField]
    private BooleanReference jump;
    [SerializeField]
    private LayerMask groundMask;

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
        isGround.Value = NoChao();
        jump.Value = !isGround.Value;
        anime.SetBool("isGround", isGround.Value);
    }

    public void Jump()
    {
        if (isGround.Value)
        {
            jump.Value = true;
            rb.AddForce(this.force.Value, ForceMode.Impulse);
            anime.SetTrigger("jump");
        }
    }

    private bool NoChao()
    {
        return Physics.Raycast(transform.position, -Vector3.up, maxDistancia, groundMask);
    }

}
