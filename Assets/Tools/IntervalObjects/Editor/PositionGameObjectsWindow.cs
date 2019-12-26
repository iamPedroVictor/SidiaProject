using UnityEngine;
using UnityEditor;

namespace IntervalObjects.Editor
{
    public class PositionGameObjectsWindow : EditorWindow
    {
        private Transform[] transforms;
        private Vector3 intervalValue;
        private OrganizeGameObjects Organize = new OrganizeGameObjects();

        [MenuItem("Sidia/Position GameObjects")]
        static void Init()
        {
            PositionGameObjectsWindow window = (PositionGameObjectsWindow)GetWindow(typeof(PositionGameObjectsWindow));
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Set GameObjects position with interval", EditorStyles.boldLabel);
            Rect position = EditorGUILayout.BeginVertical();
            GUILayout.Label("Set Interval");
            position.y += 30;
            position.x += 30;
            position.width = EditorGUIUtility.currentViewWidth - 50;
            intervalValue = EditorGUI.Vector3Field(position, "", intervalValue);
            position.y += 40;
            GUILayout.Label("", GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.Height(50));
            if (GUILayout.Button("Organize"))
            {
                Organize.SetInterval(transforms, intervalValue);
            }

            EditorGUILayout.EndVertical();
        }

        private void OnSelectionChange()
        {
            transforms = Selection.transforms;
        }
    }
}
