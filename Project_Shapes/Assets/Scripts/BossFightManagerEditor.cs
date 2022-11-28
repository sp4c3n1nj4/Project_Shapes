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

        BossFightManager tar = (BossFightManager)target;
        UpdateTimeline(tar.bossTimeline);
    }

    public void UpdateTimeline(List<BossAbilities> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];

            if (item.GetType() == typeof(BossMove))
            {
                BossMove s = item as BossMove;

                EditorGUILayout.LabelField("Boss Move " + i.ToString());
                item.delayTimer = EditorGUILayout.FloatField("Delay Timer", item.delayTimer);

                s.speed = EditorGUILayout.FloatField("Movement Speed", s.speed);
                s.position = EditorGUILayout.Vector3Field("Position", s.position);

                EditorGUILayout.Space();
            }

            if (item.GetType() == typeof(BossAttack))
            {
                BossAttack s = item as BossAttack;

                EditorGUILayout.LabelField("Boss Attack " + i.ToString());
                item.delayTimer = EditorGUILayout.FloatField("Delay Timer", item.delayTimer);

                s.damage = EditorGUILayout.FloatField("Damage", s.damage);
                s.size = EditorGUILayout.FloatField("Size radius", s.size);
                s.position = EditorGUILayout.Vector3Field("Position", s.position);
                s.rotation = EditorGUILayout.Vector3Field("Rotatiom", s.rotation);

                EditorGUILayout.Space();
            }
        }
    }
}

