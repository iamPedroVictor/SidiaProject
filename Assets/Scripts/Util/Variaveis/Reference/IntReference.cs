using System;

[Serializable]
public class IntReference
{
    public bool UsarConstante = true;
    public int ConstanteValue;
    public IntVariable Variable;

    public int Value
    {
        get { return UsarConstante ? ConstanteValue : Variable.Value; }
        set
        {
            if (UsarConstante) {
                this.ConstanteValue = value;
            }else{
                this.Variable.Value = value;
            }
        }
    }
}
