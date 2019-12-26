using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private IntReference totalDeMoedas;

    public void SomarMoeda()
    {
        totalDeMoedas.Value++;
    }

}
