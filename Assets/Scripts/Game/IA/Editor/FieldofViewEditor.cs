using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldofView))]
public class FieldofViewEditor : Editor
{
    Vector2 scroll;
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
        EditorGUILayout.LabelField("View Angle");
        position.y += EditorGUIUtility.singleLineHeight;
        position.width = EditorGUIUtility.currentViewWidth - 50;
        view.ViewAngle = EditorGUI.Slider(position,view.ViewAngle, 0, 360);
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));

        position = EditorGUILayout.BeginVertical();
        position.width = EditorGUIUtility.currentViewWidth - 50;
        EditorGUILayout.LabelField("Target Mask");
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        view.TargetMask = EditorGUI.LayerField(position,view.TargetMask);
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight));

        position = EditorGUILayout.BeginVertical();
        position.width = EditorGUIUtility.currentViewWidth - 50;
        EditorGUILayout.LabelField("Obstacle Mask");
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        view.ObstacleMask = EditorGUI.LayerField(position, view.ObstacleMask);
        EditorGUILayout.EndVertical();

        
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight * 1.2f));
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
        EditorGUILayout.LabelField("Reference view mesh filter");
        position.y += EditorGUIUtility.singleLineHeight * 1.2f;
        EditorGUI.ObjectField(position, serializedObject.FindProperty("refviewMeshFilter"));
        EditorGUILayout.EndVertical();

        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(EditorGUIUtility.singleLineHeight * 2));
        serializedObject.ApplyModifiedProperties();
    }

}
