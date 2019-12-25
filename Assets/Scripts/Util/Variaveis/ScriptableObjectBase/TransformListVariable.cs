using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variaveis/Transform List")]
public class TransformListVariable : ScriptableObject
{
    public List<Transform> Value = new List<Transform>();
}
