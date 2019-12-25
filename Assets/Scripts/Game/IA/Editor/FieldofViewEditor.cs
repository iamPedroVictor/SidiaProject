using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldofView))]
public class FieldofViewEditor : Editor
{
    Vector2 scroll;

    private readonly string[] popupOptions = { "Usar constante", "Usar variavel" };

    private GUIStyle popupStyle;

    void OnSceneGUI()
    {
        FieldofView fow = (FieldofView)target;
        Handles.color = Color.blue;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.ViewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.ViewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.ViewAngle / 2, false);

        Handles.color = Color.yellow;
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.ViewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.ViewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fow.VisibleTargets.Value)
        {
            Handles.DrawLine(fow.transform.position, visibleTarget.position);
        }

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        FieldofView view = serializedObject.targetObject as FieldofView;
        Rect position = Rect.zero;
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(5));

        position = EditorGUILayout.BeginVertical();
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));
        position.width = EditorGUIUtility.currentViewWidth - 100;
        EditorGUI.PropertyField(position, serializedObject.FindProperty("viewRadius"));
        EditorGUILayout.EndVertical();

        position = EditorGUILayout.BeginVertical();
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));
        position.width = EditorGUIUtility.currentViewWidth - 100;
        EditorGUI.PropertyField(position, serializedObject.FindProperty("viewAngle"));
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight * 1.5f));

        position = EditorGUILayout.BeginVertical();
        position.width = EditorGUIUtility.currentViewWidth - 50;
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        EditorGUI.LabelField(position, "");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("targetMask"));
        EditorGUILayout.EndVertical();

        position = EditorGUILayout.BeginVertical();
        position.width = EditorGUIUtility.currentViewWidth - 50;
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        EditorGUI.LabelField(position, "");
        EditorGUILayout.PropertyField(serializedObject.FindProperty("obstacleMask"));
        EditorGUILayout.EndVertical();


        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight * 1.5f));
        GUILayout.Label("Mesh View", GUILayout.Width(EditorGUIUtility.currentViewWidth),
        GUILayout.Height(EditorGUIUtility.singleLineHeight));
        position = EditorGUILayout.BeginVertical();
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));
        position.width = EditorGUIUtility.currentViewWidth - 100;
        EditorGUI.PropertyField(position, serializedObject.FindProperty("meshResolution"));
        EditorGUILayout.EndVertical();
        
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));

        position = EditorGUILayout.BeginVertical();
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));
        position.width = EditorGUIUtility.currentViewWidth - 100;
        EditorGUI.PropertyField(position, serializedObject.FindProperty("edgeResolveIterations"));
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));

        position = EditorGUILayout.BeginVertical();
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));
        position.width = EditorGUIUtility.currentViewWidth - 100;
        EditorGUI.PropertyField(position, serializedObject.FindProperty("edgeDstThreshold"));
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));

        position = EditorGUILayout.BeginVertical();
        position.width = EditorGUIUtility.currentViewWidth - 50;
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        position.height = 15;
        EditorGUI.ObjectField(position, serializedObject.FindProperty("refviewMeshFilter"));
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight * 2f));

        position = EditorGUILayout.BeginVertical();
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        position.height = EditorGUIUtility.singleLineHeight;
        position.width = EditorGUIUtility.currentViewWidth - 50;
        EditorGUI.PropertyField(position, serializedObject.FindProperty("visibleTargets"));
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight * 3.2f));
        serializedObject.ApplyModifiedProperties();
    }
}
