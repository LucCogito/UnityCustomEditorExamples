using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [field:SerializeField]
    public EnemyVisuals[] EnemyVisuals { get; private set; }
}
