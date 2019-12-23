using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarParticulas : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    public void Iniciar()
    {
        particle.Play();
    }

}
