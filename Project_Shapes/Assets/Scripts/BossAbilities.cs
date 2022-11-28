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
    BossMove,
    BossAttack
}

[Serializable]
public class BossAbilities
{
    public float delayTimer;
}

[Serializable]
public class BossMove : BossAbilities
{
    public float speed;

    public Vector3 position;
}

[Serializable]
public class BossAttack : BossAbilities
{
    public Vector3 position;

    public Vector3 rotation;

    public float damage;

    public float size;
    
}

[CustomPropertyDrawer(typeof(BossMove))]
public class BossMoveDrawer : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var speedField = new PropertyField(property.FindPropertyRelative("speed"));
        var positionField = new PropertyField(property.FindPropertyRelative("position"));

        container.Add(speedField);
        container.Add(positionField);

        return container;
    }
}