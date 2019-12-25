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
    private float timer = 50;
    [SerializeField]
    [Range(0,1)]
    private float multiplyVelocityAppend;
    
    // Update is called once per frame
    void Update()
    {
        if (isRunning.Value)
        {
            timer += Time.deltaTime;
            tempoDeJogo.Value = (int)Time.timeSinceLevelLoad % 3600;
            if (tempoDeJogo.Value > nextVelocidade) {
                nextVelocidade += 10;
                float velocidade = boxVelocidade.Value + (boxVelocidade.Value * multiplyVelocityAppend);
                boxVelocidade.Value = velocidade;
            }
        }
    }
}
