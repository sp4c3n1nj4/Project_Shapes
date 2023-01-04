using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class BossTimelineMenu : EditorWindow
{
    private BossFightManager manager;
    private SerializedObject serializedList;
    private ReorderableList orderedList;

    private static Vector2 windowsMinSize = Vector2.one * 500f;
    private static Rect listRect = new Rect(Vector2.zero, windowsMinSize);

    [SerializeField]
    BossAbilities abilityClass = new BossMove();

    [MenuItem("Timeline/Boss Abilty")]
    static void Init()
    {
        GetWindow<BossTimelineMenu>(true, "Boss Timeline");
    }

    private void OnEnable()
    {
        manager = FindObjectOfType<BossFightManager>();
        if (manager)
        {
            serializedList = new SerializedObject(manager);

            orderedList = new ReorderableList(serializedList, serializedList.FindProperty("bossTimeline"), true, true, false, true);

            orderedList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Game Objects");
            orderedList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;

                GUIContent objectLable = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, orderedList.serializedProperty.GetArrayElementAtIndex(index), objectLable);
            };
        }
    }

    private void OnInspectorUpdate()
    {
        Repaint();
    }

    void AddMenuItemForClass(GenericMenu menu, string menuPath, BossAbilities ability)
    {
        menu.AddItem(new GUIContent(menuPath), abilityClass.Equals(ability), OnClassSelected, ability);
    }

    void OnClassSelected(object ability)
    {
        abilityClass = (BossAbilities)ability;

        manager.bossTimeline.Add((BossAbilities)ability);
        Debug.Log((BossAbilities)ability);
    }

    private void OnGUI()
    {
        if (serializedList == null)
        {
            throw new UnassignedReferenceException();
        }
        else
        {
            serializedList.Update();
            orderedList.DoList(listRect);
            serializedList.ApplyModifiedProperties();
        }

        GUILayout.Space(orderedList.GetHeight() + 30f);
        
        if (GUILayout.Button("Add Ability"))
        {
            GenericMenu menu = new GenericMenu();

            AddMenuItemForClass(menu, "Boss Move", new BossMove());
            AddMenuItemForClass(menu, "Boss Attack", new BossAttack());

            menu.ShowAsContext();
        }
    }

}
