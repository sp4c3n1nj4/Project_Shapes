using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BossFightManager))]
[CanEditMultipleObjects]
public class BossFightManagerEditor : Editor
{
    //[SerializeReference]
    //public List<BossAbilities> serialRefList = new List<BossAbilities>() { new BossAbilities() { delayTimer = 1 } };

    //[SerializeReference]
    //private BossAbilities bossMove = new BossMove();
    //[SerializeReference]
    //private BossAbilities bossAttack = new BossAttack();

    //private BossFightManager manager;

    //private void Awake()
    //{
    //    manager = FindObjectOfType<BossFightManager>();
    //}

    //public override void OnInspectorGUI()
    //{
    //    EditorGUILayout.LabelField("Boss Fight Timeline");

    //    //serializedObject.Update();
    //    //var property = serializedObject.FindProperty("bossTimeline");
    //    //EditorGUILayout.PropertyField(property, true);

    //    BossFightManager tar = (BossFightManager)target;
    //    UpdateTimeline(tar.bossTimeline);

    //    serializedObject.ApplyModifiedProperties();
    //    EditorApplication.update.Invoke();

    //}

    //void OnMoveSelected(object ability)
    //{
    //    bossMove = (BossMove)ability;

    //    manager.bossTimeline.Add((BossMove)ability);
    //}

    //void OnAttackSelected(object ability)
    //{
    //    bossAttack = (BossAttack)ability;

    //    manager.bossTimeline.Add((BossMove)ability);
    //}

    //void AddMoveItemForClass(GenericMenu menu, string menuPath, BossMove ability)
    //{
    //    menu.AddItem(new GUIContent(menuPath), bossMove.Equals(ability), OnMoveSelected, ability);
    //}

    //void AddAttackItemForClass(GenericMenu menu, string menuPath, BossAttack ability)
    //{
    //    menu.AddItem(new GUIContent(menuPath), bossAttack.Equals(ability), OnAttackSelected, ability);
    //}


    //public void UpdateTimeline(List<BossAbilities> list)
    //{
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        var item = list[i];

    //        if (item.GetType() == typeof(BossAbilities))
    //        {
    //            EditorGUILayout.LabelField("Boss Ability " + i.ToString());
    //            item.delayTimer = EditorGUILayout.FloatField("Delay Timer", item.delayTimer);

    //            EditorGUILayout.Space();
    //        }

    //        if (item.GetType() == typeof(BossMove))
    //        {
    //            BossMove s = item as BossMove;

    //            EditorGUILayout.LabelField("Boss Move " + i.ToString());
    //            item.delayTimer = EditorGUILayout.FloatField("Delay Timer", item.delayTimer);

    //            s.speed = EditorGUILayout.FloatField("Movement Speed", s.speed);
    //            s.position = EditorGUILayout.Vector3Field("Position", s.position);

    //            EditorGUILayout.Space();
    //        }

    //        if (item.GetType() == typeof(BossAttack))
    //        {
    //            BossAttack s = item as BossAttack;

    //            EditorGUILayout.LabelField("Boss Attack " + i.ToString());
    //            item.delayTimer = EditorGUILayout.FloatField("Delay Timer", item.delayTimer);

    //            s.damage = EditorGUILayout.FloatField("Damage", s.damage);
    //            s.size = EditorGUILayout.FloatField("Size radius", s.size);
    //            s.position = EditorGUILayout.Vector3Field("Position", s.position);
    //            s.rotation = EditorGUILayout.Vector3Field("Rotatiom", s.rotation);

    //            EditorGUILayout.Space();
    //        }
    //    }

    //    if (GUILayout.Button("Add Ability"))
    //    {
    //        GenericMenu menu = new GenericMenu();

    //        AddMoveItemForClass(menu, "Boss Move", new BossMove());
    //        AddAttackItemForClass(menu, "Boss Attack", new BossAttack());

    //        menu.ShowAsContext();
    //    }
    //}
}

