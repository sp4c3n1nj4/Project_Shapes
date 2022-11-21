using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BossFightManager))]
[CanEditMultipleObjects]
public class BossFightManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("Boss Fight Timeline");
        var serializedObject = new SerializedObject(target);
        var property = serializedObject.FindProperty("bossTimeline");
        serializedObject.Update();
        EditorGUILayout.PropertyField(property, true);
        serializedObject.ApplyModifiedProperties();
    }
}

