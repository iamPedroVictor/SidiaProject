using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    [SerializeField]
    private Text textTempo;
    [SerializeField]
    private IntReference tempoDeJogo;

    private void Update()
    {
        textTempo.text = tempoDeJogo.Value.ToString();
    }

}
