using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum COMPARE
{
    Width,
    Heigth,
    Size
}

class CompareTexture2D : IComparer<Texture2D>
{
    private COMPARE compare;
    public CompareTexture2D(COMPARE _compare)
    {
        this.compare = _compare;
    }
    public int Compare(Texture2D x, Texture2D y)
    {
        if (this.compare == COMPARE.Heigth)
        {
            float xHeigth = x.width;
            float yHeigth = y.width;
            return xHeigth.CompareTo(yHeigth);
        }
        else if (this.compare == COMPARE.Size) {
            float xSize = x.width * x.height;
            float ySize = y.width * y.height;
            return xSize.CompareTo(ySize);
        }
        float xWidth = x.width;
        float yWidth = y.width;
        return xWidth.CompareTo(yWidth);
    }
}

public class SearchTexturesWindow : EditorWindow
{
    string Title = "Search Textures";
    Vector2 scroll = Vector2.zero;
    Vector2 MaxSize = new Vector2(400, 500);

    private COMPARE compareOption = COMPARE.Width;

    private static List<Texture2D> textures2D = new List<Texture2D>();

    [MenuItem("Sidia/Search Textures")]
    static void Init()
    {
        SearchTexturesWindow window = (SearchTexturesWindow)GetWindow(typeof(SearchTexturesWindow));
        textures2D.Clear();
        window.Show();
    }

    private void Awake()
    {
        textures2D.Clear();
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
            FindTextures();
            
        }
        if(textures2D.Count > 0)
        {
            float maxHeight = textures2D.Count > 0 ? 20 + (120 * textures2D.Count) : 500f;
            scroll = EditorGUILayout.BeginScrollView(scroll, true, false, GUILayout.MaxWidth(400), GUILayout.MaxHeight(maxHeight));
            GUILayout.Label("", GUILayout.Width(380), GUILayout.Height(maxHeight));

            for (int i = 0; i < textures2D.Count; i++)
            {
                Rect position = new Rect(-50, 10 + (i * 120) , 250, 100);
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

    private void FindTextures()
    {
        string[] textures = GetTextures();
        List<string> filtedTextures = FilterPaths(textures);
        foreach (string path in filtedTextures)
        {
            Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D));
            textures2D.Add(tex);
        }

    }

    private List<string> FilterPaths(string[] array) {
        List<string> filted = new List<string>();
        foreach (string texture in array)
        {
            string pathFile = AssetDatabase.GUIDToAssetPath(texture);
            if (pathFile.Contains("Assets/") && !pathFile.Contains(".psd"))
            {
                filted.Add(pathFile);
            }
        }
        return filted;
    }

    private string[] GetTextures() {

        string[] texturesArray = AssetDatabase.FindAssets("t:texture");
        return texturesArray;
    }

}
