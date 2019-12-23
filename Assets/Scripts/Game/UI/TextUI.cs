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
    [SerializeField]
    private string baseString;

    private void Update()
    {
        textTempo.text = string.Format(baseString,tempoDeJogo.Value.ToString());
    }

}
