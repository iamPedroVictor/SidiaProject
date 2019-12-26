using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CoinSpawner))]
public class CoinSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(5));
        Rect position = Rect.zero;
        GUIContent gUI = new GUIContent();
        gUI.text = "Tempo da partida";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("TempoDeJogo"), gUI);
        gUI.text = "Ponto de spawn";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("InicioTransform"), gUI);
        gUI.text = "Jogo rodando";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isRunning"), gUI);
        EditorGUILayout.Space();
        position = EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Chance de instanciar: ");
        position = EditorGUILayout.BeginHorizontal();
        position.x = 5;
        position.width -= 25;
        SerializedProperty porcentagem = serializedObject.FindProperty("porcentage");
        porcentagem.floatValue = EditorGUILayout.Slider(
            porcentagem.floatValue, 0f, 1f);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
        gUI.text = "Tempo entre spawn";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("proximoTempo"), gUI);
        gUI.text = "Prefab";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("coinPrefab"), gUI);
        gUI.text = "Tag do objeto";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("CoinTag"), gUI);
        gUI.text = "Tamanho da reserva";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("size"), gUI);
        gUI.text = "Primeiro spawn";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("first"), gUI);
        gUI.text = "Deslocamento Y";
        EditorGUILayout.PropertyField(serializedObject.FindProperty("offsetY"), gUI);
        serializedObject.ApplyModifiedProperties();
    }
}
