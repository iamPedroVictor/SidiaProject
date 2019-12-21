using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloatReference
{
    public bool UsarConstante = true;
    public float ConstanteValue;
    public FloatVariable Variable;

    public float Value
    {
        get { return UsarConstante ? ConstanteValue : Variable.Value; }
        
        set
        {
            if (UsarConstante){
                this.ConstanteValue = value;
            } else{
                this.Variable.Value = value;
            }
        }
    }
}
