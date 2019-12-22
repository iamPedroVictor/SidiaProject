using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Vector3 force = new Vector3(0, 1, 0);

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(this.force,ForceMode.Impulse);
        }
    }
}
