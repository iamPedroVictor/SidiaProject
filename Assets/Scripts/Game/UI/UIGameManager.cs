using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private float segundosDeEspera;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    public void HabilitarPainelGameOver() {
        StartCoroutine("TempoDeEspera");
        gameOverPanel.SetActive(true);
    }

    private IEnumerator TempoDeEspera()
    {
        yield return new WaitForSeconds(segundosDeEspera);
    }
    
}
