using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StringReference
{
    public bool UsarConstante = true;
    public string ConstanteValue;
    public StringVariable Variable;

    public string Value
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
