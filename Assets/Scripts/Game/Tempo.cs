using UnityEngine;
using System.Collections;

public class Tempo : MonoBehaviour
{

    [SerializeField]
    private IntReference tempoDeJogo;
    [SerializeField]
    private BooleanReference isRunning;
    
    // Update is called once per frame
    void Update()
    {
        if (isRunning.Value)
        {
            tempoDeJogo.Value = (int)Time.timeSinceLevelLoad % 60;
        }
    }
}
