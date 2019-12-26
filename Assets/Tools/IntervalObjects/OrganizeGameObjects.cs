using UnityEngine;
using System.Collections.Generic;

namespace IntervalObjects
{
    public class OrganizeGameObjects
    {
        private List<GameObject> gameObjectsList = new List<GameObject>();

        public void SetInterval(Transform[] transforms, Vector3 intervalValue){
            RepositionGameObjects(transforms, intervalValue);
        }

        public void SetInterval(Transform[] transforms, Vector3 intervalValue, Vector3 basePosition)
        {
            transforms[0].position = basePosition;
            RepositionGameObjects(transforms, intervalValue);
        }
        public Transform[] GetSelectedGameObjects(GameObject[] gameObjectsArray)
        {
            PopulateList(gameObjectsArray, gameObjectsList);
            Transform[] transforms = new Transform[gameObjectsList.Count];
            for (int i = 0; i < gameObjectsList.Count; i++){
                transforms[i] = gameObjectsList[i].transform;
            }
            return transforms;
        }
        
        public void Clean(){
            gameObjectsList.Clear();
        }


        private void RepositionGameObjects(Transform[] transforms, Vector3 intervalValue){
            for (int i = 1; i < transforms.Length; i++){
                Vector3 before = transforms[i - 1].position;
                Vector3 newPosition = before + intervalValue;
                transforms[i].position = newPosition;
            }
        }

        private void PopulateList(GameObject[] gameObjectsArray, List<GameObject> list){
            for (int i = 0; i < gameObjectsArray.Length; i++){
                if (!list.Contains(gameObjectsArray[i])){
                    list.Add(gameObjectsArray[i]);
                }
            }
        }
    }
}

