using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script creates and joins rooms", MessageType.Info);

        RoomManager roomManager = (RoomManager)target;
        //if (GUILayout.Button("Join Random Room"))
        //{
        //    roomManager.JoinRandomRoom();
        //}

        if (GUILayout.Button("Join School Room"))
        {
            roomManager.OnEnterButtonClicked_School();
        }

        if (GUILayout.Button("Join Outdoor Room"))
        {
            roomManager.OnEnterButtonClicked_Outdoor();

        }
        if (GUILayout.Button("Join Clinic Room"))
        {
            roomManager.OnEnterButtonClicked_Clinic();

        }

        if (GUILayout.Button("Join XR Room"))
        {
            roomManager.OnEnterButtonClicked_XRroom();
        }
        // if (GUILayout.Button("Join Dream 1"))
        // {
        //     roomManager.OnEnterButtonClicked_Dream1();

        // }
        // if (GUILayout.Button("Join Dream 2"))
        // {
        //     roomManager.OnEnterButtonClicked_Dream2();

        // }
        // if (GUILayout.Button("Join Dream 3"))
        // {
        //     roomManager.OnEnterButtonClicked_Dream3();

        // }
        // if (GUILayout.Button("Join Dream 4"))
        // {
        //     roomManager.OnEnterButtonClicked_Dream4();

        // }
    }
}
