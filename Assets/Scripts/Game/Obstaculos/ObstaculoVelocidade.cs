using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoVelocidade : MonoBehaviour
{
    [SerializeField]
    private FloatReference VelocidadeObstaculos;
    [SerializeField]
    private IntReference tempo;
    [SerializeField]
    [Range(0, 1)]
    private float plus;
    private bool Aumentou = false;

    private void Update()
    {
        if(tempo.Value % 10 == 0)
        {
            if (!Aumentou)
            {
                Aumentar();
            }
        }else if(tempo.Value % 11 == 0)
        {
            Aumentou = false;
        }
    }

    public void Aumentar()
    {
        VelocidadeObstaculos.Value = VelocidadeObstaculos.Value + plus;
    }

}
