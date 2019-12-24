using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class TransformListReference
{
    public bool UsarConstante = true;
    public List<Transform> ConstanteValue;
    public TransformListVariable Variable;

    public List<Transform> Value
    {
        get { return this.UsarConstante ? this.ConstanteValue : this.Variable.Value; }

        set
        {
            if (this.UsarConstante)
            {
                this.ConstanteValue = value;
            }
            else
            {
                this.Variable.Value = value;
            }
        }
    }

}
