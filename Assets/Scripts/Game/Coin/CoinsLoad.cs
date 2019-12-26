using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLoad : MonoBehaviour
{
    [SerializeField]
    private IntReference moedasTotal;
    [SerializeField]
    private StringReference playerPrefsMoeda;

    public void Awake()
    {
        moedasTotal.Value = PlayerPrefs.GetInt(playerPrefsMoeda.Value, 0);
    }

}
