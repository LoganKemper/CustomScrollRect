using UnityEditor;
using UnityEditor.UI;

// Remember to place me in a folder named "Editor"!

[CustomEditor(typeof(CustomScrollRect))]
public class CustomScrollRectEditor : ScrollRectEditor
{
    private SerializedProperty _preventScrolling;
    private SerializedProperty _preventDragging;

    protected override void OnEnable()
    {
        base.OnEnable();
        _preventScrolling = serializedObject.FindProperty(nameof(_preventScrolling));
        _preventDragging = serializedObject.FindProperty(nameof(_preventDragging));
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();
        EditorGUILayout.LabelField("Custom Scroll Rect Options", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_preventScrolling);
        EditorGUILayout.PropertyField(_preventDragging);
        serializedObject.ApplyModifiedProperties();
    }
}
