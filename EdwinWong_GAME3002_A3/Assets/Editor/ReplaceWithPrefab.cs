using UnityEngine;
using UnityEditor;

public class ReplaceWithPrefab : EditorWindow
{
    GameObject prefab;

    [MenuItem("Tools/Replace Selected With Prefab")]
    public static void ShowWindow()
    {
        GetWindow<ReplaceWithPrefab>("Replace With Prefab");
    }

    private void OnGUI()
    {
        GUILayout.Label("Replace Selected Objects", EditorStyles.boldLabel);

        prefab = (GameObject)EditorGUILayout.ObjectField(
            "Prefab",
            prefab,
            typeof(GameObject),
            false
        );

        if (prefab == null)
        {
            EditorGUILayout.HelpBox(
                "Drag a prefab into the field above.",
                MessageType.Warning
            );
            return;
        }

        if (GUILayout.Button("Replace Selected"))
        {
            ReplaceSelected();
        }
    }

    void ReplaceSelected()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogWarning("No objects selected.");
            return;
        }

        Undo.IncrementCurrentGroup();

        foreach (GameObject oldObject in selectedObjects)
        {
            // Save transform information
            Transform oldTransform = oldObject.transform;

            Vector3 position = oldTransform.position;
            Quaternion rotation = oldTransform.rotation;
            Vector3 scale = oldTransform.localScale;
            Transform parent = oldTransform.parent;

            // Create prefab instance
            GameObject newObject =
                (GameObject)PrefabUtility.InstantiatePrefab(prefab);

            // Restore transform information
            newObject.transform.SetParent(parent);
            newObject.transform.position = position;
            newObject.transform.rotation = rotation;
            newObject.transform.localScale = scale;

            // Register undo
            Undo.RegisterCreatedObjectUndo(
                newObject,
                "Replace With Prefab"
            );

            // Destroy old object
            Undo.DestroyObjectImmediate(oldObject);
        }

        Undo.CollapseUndoOperations(
            Undo.GetCurrentGroup()
        );

        Debug.Log(
            $"Replaced {selectedObjects.Length} objects with {prefab.name}."
        );
    }
}
