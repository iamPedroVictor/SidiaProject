using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace SearchTextures
{
    public class SearchTextures
    {
        public List<Texture2D> Search()
        {
            string[] textures = GetTextures();
            List<string> filtedTextures = FilterPaths(textures);
            List<Texture2D> tex2D = new List<Texture2D>();
            foreach (string path in filtedTextures)
            {
                Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D));
                tex2D.Add(tex);
            }
            return tex2D;
        }

        private List<string> FilterPaths(string[] array)
        {
            List<string> filted = new List<string>();
            foreach (string texture in array)
            {
                string pathFile = AssetDatabase.GUIDToAssetPath(texture);
                if (pathFile.Contains("Assets/"))
                {
                    filted.Add(pathFile);
                }
            }
            return filted;
        }

        private string[] GetTextures()
        {

            string[] texturesArray = AssetDatabase.FindAssets("t:texture");
            return texturesArray;
        }
    }
}
