using UnityEngine;
using System.Collections;

public class Tempo : MonoBehaviour
{

    [SerializeField]
    private IntReference tempoDeJogo;
    [SerializeField]
    private BooleanReference isRunning;
    [SerializeField]
    private FloatReference boxVelocidade;
    private int nextVelocidade = 10;
    
    // Update is called once per frame
    void Update()
    {
        if (isRunning.Value)
        {
            tempoDeJogo.Value = (int)Time.timeSinceLevelLoad % 60;
            if (tempoDeJogo.Value > nextVelocidade) {
                nextVelocidade += 10;
                boxVelocidade.Value += boxVelocidade.Value + (boxVelocidade.Value * 0.20f);
            }
        }
    }
}
