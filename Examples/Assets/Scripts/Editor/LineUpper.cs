using UnityEditor;
using UnityEngine;

public class LineUpper
{
    // It seems that enemies are scattered around the scene. We can line them up by selecting them all, then choosing "Edit/Line 'em Up!" or pressing Ctrl + Alt + L
    [MenuItem("Edit/Line 'em Up! ^%&L")]
    public static void LineUp()
    {
        foreach (var gameObject in Selection.gameObjects)
        {
            Undo.RecordObject(gameObject.transform, "line up the objects");
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localPosition = new Vector3(1.2f, 0, 0) * gameObject.transform.GetSiblingIndex();
        }
    }

    [MenuItem("Edit/Line 'em Up! ^%&L", isValidateFunction:true)]
    public static bool ValidateLineUp() => Selection.gameObjects.Length > 0; // But first we should make sure that there is an object selected
}
