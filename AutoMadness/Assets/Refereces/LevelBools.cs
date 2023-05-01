using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelBools : ScriptableObject
{
    [SerializeField]
    private List<bool> _value;
    public List<bool> Value
    {
        get { return _value; }
        set { _value = value; }
    }
    
}
