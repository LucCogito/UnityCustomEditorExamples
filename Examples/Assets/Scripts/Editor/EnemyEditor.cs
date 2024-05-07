using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    private SerializedObject enemySO;
    private SerializedProperty propertyEnemyData;
    private SerializedProperty propertyEnemyType;
    private SerializedProperty propertyMoveSpeed;

    private void OnEnable() // Is called only once, when the object was selected
    {
        enemySO = serializedObject; // Get selected Enemy as SerializedObject

        propertyEnemyData = enemySO.FindProperty("enemyData"); // propertyPath string must match its name in Enemy class
        propertyEnemyType = enemySO.FindProperty("enemyType");
        propertyMoveSpeed = enemySO.FindProperty("moveSpeed");
    }

    public override void OnInspectorGUI() // Overrides default inspector. Called multiple times per frame
    {
        enemySO.Update();

        Rect space = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(20));
        EditorGUI.PropertyField(space, propertyEnemyData); // EditorGUI requires UnityEngine.Rect to position the field properly

        EditorGUILayout.PropertyField(propertyEnemyType); // EditorGUILayout creates that Rect automatically

        if (propertyEnemyType.enumValueIndex != (int)EnemyType.Turret) // Let's show movement speed field only when the enemy is not a stationary turret
            EditorGUILayout.PropertyField(propertyMoveSpeed);

        if (enemySO.ApplyModifiedProperties())
            foreach (Enemy enemy in enemySO.targetObjects) // And let enemies update their visuals if anything changed
                enemy.UpdateVisualsAccordingToType();
    }
}
