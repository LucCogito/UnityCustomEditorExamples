using UnityEditor;
using UnityEngine;

public class LineUpTool : EditorWindow
{
    // Now let's remake LineUpper into its own window
    [MenuItem ("Tools/LineUp")]
    public static void OpenWindow() => GetWindow<LineUpTool>("Line Up"); // Choose "Tools/LineUp" to open the tool's window

    private void OnEnable() => Selection.selectionChanged += Repaint; // Refresh the window whenever something's selected
    private void OnDisable() => Selection.selectionChanged -= Repaint;

    private void OnGUI()
    {
        GUILayout.Label("Let's Line 'em Up!");
        using (new EditorGUI.DisabledScope(Selection.gameObjects.Length == 0)) // Execute below code only when more than 0 objects are selected
        {
            if(GUILayout.Button("LineUp")) // Draw a button and react to it
                foreach (var gameObject in Selection.gameObjects)
                {
                    Undo.RecordObject(gameObject.transform, "line up the objects");
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.transform.localPosition = new Vector3(1.2f, 0, 0) * gameObject.transform.GetSiblingIndex();
                }
        }
    }
}
