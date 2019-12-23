using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BooleanReference
{
    public bool UsarConstante = true;
    public bool ConstanteValue;
    public BooleanVariable Variable;

    public bool Value
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
