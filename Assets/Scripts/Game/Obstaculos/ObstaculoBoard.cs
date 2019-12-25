using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoBoard : MonoBehaviour
{
    [SerializeField]
    private BooleanReference first;
    [SerializeField]
    private RectTransform boardTransform;
    [SerializeField]
    private Transform obstaculo;
    [SerializeField]
    private float offsetY = 1.5f;

    public RectTransform BoardTransform { get => boardTransform; set => boardTransform = value; }
    public Transform Obstaculo { get => obstaculo; set => obstaculo = value; }
    public float OffsetY { get => offsetY; set => offsetY = value; }

    // Update is called once per frame
    void Update()
    {
        Vector3 obstaculoWordPosition = Obstaculo.position;
        obstaculoWordPosition.y += OffsetY;

        BoardTransform.position = obstaculoWordPosition;
    }
}
