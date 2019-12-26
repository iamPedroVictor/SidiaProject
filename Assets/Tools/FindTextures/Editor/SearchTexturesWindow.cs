using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SearchTextures.Enum;

namespace SearchTextures.Editor
{
    public class SearchTexturesWindow : EditorWindow
    {
        string Title = "Search Textures";
        Vector2 scroll = Vector2.zero;
        Vector2 MaxSize = new Vector2(400, 500);

        private COMPARE compareOption = COMPARE.Width;

        private static List<Texture2D> textures2D = new List<Texture2D>();
        private static SearchTextures searchTextures = new SearchTextures();

        [MenuItem("Sidia/Search Textures")]
        static void Init()
        {
            SearchTexturesWindow window = (SearchTexturesWindow)GetWindow(typeof(SearchTexturesWindow));
            window.titleContent = new GUIContent("Search Textures");
            textures2D.Clear();
            window.Show();
        }

        private void OnGUI()
        {
            this.maxSize = MaxSize;

            GUILayout.Label(Title, EditorStyles.boldLabel);
            bool find = GUILayout.Button("Search Textures");
            GUILayout.BeginHorizontal();
            bool sort = GUILayout.Button("Sort");
            compareOption = (COMPARE)EditorGUILayout.EnumPopup("Choose an option to sort", compareOption);
            GUILayout.EndHorizontal();
            if (sort)
            {
                textures2D.Sort(new CompareTexture2D(compareOption));
            }

            if (find)
            {
                textures2D = searchTextures?.Search();
                Debug.Log(searchTextures);

            }
            if (textures2D.Count > 0)
            {
                float maxHeight = textures2D.Count > 0 ? 20 + (120 * textures2D.Count) : 500f;
                scroll = EditorGUILayout.BeginScrollView(scroll, true, false, GUILayout.MaxWidth(400), GUILayout.MaxHeight(maxHeight));
                GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(maxHeight));

                for (int i = 0; i < textures2D.Count; i++)
                {
                    Rect position = new Rect(15, 50 + (i * 120), 64, 64);
                    GUI.DrawTexture(position, textures2D[i], ScaleMode.ScaleToFit);
                    Rect labelPosition = new Rect(150, 50 + (i * 120), 200, 100);
                    GUI.Label(labelPosition, string.Format("File name: {0}", textures2D[i].name));
                    labelPosition.y += 20;
                    GUI.Label(labelPosition, string.Format("Width: {0}", textures2D[i].width));
                    labelPosition.y += 20;
                    GUI.Label(labelPosition, string.Format("Heigth: {0}", textures2D[i].height));
                    labelPosition.y += 20;
                    GUI.Label(labelPosition, string.Format("Area Size: {0}", textures2D[i].width * textures2D[i].height));

                }
                GUILayout.EndScrollView();
            }
        }

    }
}