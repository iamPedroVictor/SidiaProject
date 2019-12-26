using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSave : MonoBehaviour
{
    [SerializeField]
    private IntReference moedasTotal;
    [SerializeField]
    private StringReference playerPrefsMoeda;

    public void SalvarMoedas(){
        PlayerPrefs.SetInt(playerPrefsMoeda.Value, moedasTotal.Value);
    }
}
