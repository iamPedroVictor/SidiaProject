using System;
using UnityEngine;

[Serializable]
public class Vector3Reference
{
    public bool UsarConstante = true;
    public Vector3 ConstanteValue;
    public Vector3Variable Variable;

    public Vector3 Value
    {
        get { return UsarConstante ? ConstanteValue : Variable.Value; }
        set
        {
            if (UsarConstante)
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
