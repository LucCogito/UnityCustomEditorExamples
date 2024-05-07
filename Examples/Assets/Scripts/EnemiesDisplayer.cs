using System;
using UnityEditor;
using UnityEngine;

public class EnemiesDisplayer : MonoBehaviour
{
    [SerializeField]
    private Enemy[] enemies;

    private void OnDrawGizmosSelected() // Used for drawing stuff in Scene View when gameObject is selected
    {
        foreach (var enemy in enemies)
        {
            Gizmos.DrawLine(transform.position, enemy.transform.position); // Some funcions are in Gizmos class, some are in Handles
#if UNITY_EDITOR
            // Though remember that Handles require UnityEditor namespace and must be excluded from the build
            Handles.PositionHandle(enemy.transform.position, enemy.transform.rotation); 
#endif
        }
    }

    private void OnDrawGizmos() // Used for always drawing stuff in Scene View
    {
        foreach (var enemy in enemies)
        {
            Handles.Label(enemy.transform.position + new Vector3(-.5f, 1, 0), Enum.GetNames(typeof(EnemyType))[(int)enemy.EnemyType]);
        }
    }
}
