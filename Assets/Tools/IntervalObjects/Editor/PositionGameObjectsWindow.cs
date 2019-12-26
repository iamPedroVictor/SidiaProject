using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace IntervalObjects.Editor
{
    public class PositionGameObjectsWindow : EditorWindow
    {
        private int indexOption = 0;
        private string[] options = new[] { "Use fist GameObject position", "Define vector3 to position" };
        private bool useVector3ToBasePosition = false;

        private bool objectsSelected = false;
        private Transform[] transforms;

        private Vector3 intervalValue;
        private Vector3 vector3BasePosition = Vector3.zero;

        private OrganizeGameObjects Organize = new OrganizeGameObjects();

        [MenuItem("Sidia/Position GameObjects")]
        static void Init(){
            PositionGameObjectsWindow window = (PositionGameObjectsWindow)GetWindow(typeof(PositionGameObjectsWindow));
            window.titleContent = new GUIContent("Reposition GameObjects");
            window.Show();
        }

        private void OnGUI(){
            GUILayout.Label("Set GameObjects position with interval", EditorStyles.boldLabel);
            //position = OldDraw(position);
            EditorGUILayout.LabelField("Set Interval");
            intervalValue = EditorGUILayout.Vector3Field("",intervalValue);
            EditorGUILayout.LabelField("Use Vector 3 to base position?");
            indexOption = EditorGUILayout.Popup(indexOption, options);
            useVector3ToBasePosition = (indexOption != 0);
            if (useVector3ToBasePosition){
                vector3BasePosition = EditorGUILayout.Vector3Field("", vector3BasePosition);
            }
            if(GUILayout.Button("Reposition GameObjects")){
                if (!objectsSelected){
                    Debug.LogError("No GameObjects selected");
                }else{
                    if (useVector3ToBasePosition){
                        Organize.SetInterval(transforms, intervalValue, vector3BasePosition);
                    }else{
                        Organize.SetInterval(transforms, intervalValue);
                    }
                }
            }
        }

        private void OnSelectionChange(){
            if(Selection.gameObjects.Length == 0){
                objectsSelected = false;
                Organize.Clean();
            }else{
                objectsSelected = true;
                transforms = Organize.GetSelectedGameObjects(Selection.gameObjects);
            }
        }

    }
}
