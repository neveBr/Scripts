using DataObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameDataObjectEditorWindow : ExtendedEditorWindow
{
    string propertyName = "gameData";
    [MenuItem("Tools/Game Data Editor")]
    public static void DisplayEditorWindow()
    {
/*        Type ttt = Type.GetType("AnimationEventData_");
        var myObject = (AnimationEventData_)Activator.CreateInstance(ttt); // AnimationEventData_ => abstract class of data, objects and applyData() method*/

        GameDataObjectEditorWindow window = GetWindow<GameDataObjectEditorWindow>("Game Data Editor");
        window.serializedObject = new SerializedObject(new GameDataAnimationEvents());

    }
    public static void Open(GameDataAnimationEvents dataObject)
    {
        GameDataObjectEditorWindow window = GetWindow<GameDataObjectEditorWindow>("Game Data Editor");
        window.serializedObject = new SerializedObject(dataObject);
    }
    private void OnGUI()
    {
        //EditorGUILayout.TextField("gameData", propertyName);

        currentProperty = serializedObject.FindProperty("gameData");
        //DrawProperties(currentProperty, true);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
        DrawSidebar(currentProperty);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginHorizontal("box", GUILayout.ExpandHeight(true));
        if(selectedProperty != null)
        {
            DrawSelectedPropertiesPanel();
        }
        else
        {
            EditorGUILayout.LabelField("Select an Item");
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        Apply();
    }
    void DrawSelectedPropertiesPanel()
    {
        currentProperty = selectedProperty;
        EditorGUILayout.BeginHorizontal("box");

        DrawField("name", true);
        DrawField("title", true);

        EditorGUILayout.EndHorizontal();
    }
}
