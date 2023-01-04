using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[Serializable]
public enum BossAbilityEnum
{
    //contains all possible boss abilities
    BossMove,
    BossAttack
}

[Serializable]
public class BossAbilities
{
    //parent class for all boss abilities
    [SerializeReference]
    public float delayTimer;
}

[Serializable]
public class BossMove : BossAbilities
{
    //child class for boss movement
    [SerializeReference]
    public float speed;
    [SerializeReference]
    public Vector3 position;
}

[Serializable]
public class BossAttack : BossAbilities
{
    //child class for boss attacks
    [SerializeReference]
    public Vector3 position;
    [SerializeReference]
    public Vector3 rotation;
    [SerializeReference]
    public float damage;
    [SerializeReference]
    public float size;
}

//[CustomPropertyDrawer(typeof(BossMove))]
//public class BossMoveDrawer : PropertyDrawer
//{
//    //a custom unity editor drawer for the BossMove class to display its variables
//    public override VisualElement CreatePropertyGUI(SerializedProperty property)
//    {
//        var container = new VisualElement();

//        var speedField = new PropertyField(property.FindPropertyRelative("speed"));
//        var positionField = new PropertyField(property.FindPropertyRelative("position"));

//        container.Add(speedField);
//        container.Add(positionField);

//        return container;
//    }
//}