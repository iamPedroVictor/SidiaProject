using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameplayManager : MonoBehaviour
{
    private GameObject gameplayPanel;
    [SerializeField]
    private IntReference partidasJogadas;
    
    void Awake()
    {
        if(partidasJogadas.Value < 3)
        {
            partidasJogadas.Value++;
        }
    }

    public void DesabilitarGameplayUI()
    {
        gameplayPanel.SetActive(false);
    }
}
