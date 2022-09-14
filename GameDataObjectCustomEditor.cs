using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DataObjects;
using UnityEditor.Callbacks;

public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceID, int line)
    {
        GameDataAnimationEvents obj = EditorUtility.InstanceIDToObject(instanceID) as GameDataAnimationEvents;
        if (obj != null)
        {
            GameDataObjectEditorWindow.Open(obj);
            return true;
        }
        return false;

    }
}


[CustomEditor(typeof(GameDataAnimationEvents))]
public class GameDataObjectCustomEditor : Editor
{



    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Open Editor"))
        {
            GameDataObjectEditorWindow.Open((GameDataAnimationEvents)target);
        }
    }
}
