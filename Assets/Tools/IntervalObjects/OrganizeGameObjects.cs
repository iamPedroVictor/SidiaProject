using UnityEngine;

namespace IntervalObjects
{
    public class OrganizeGameObjects
    {
        public void SetInterval(Transform[] transforms, Vector3 intervalValue)
        {
            for (int i = 1; i < transforms.Length; i++)
            {
                Vector3 before = transforms[i - 1].position;
                Vector3 newPosition = before + intervalValue;
                transforms[i].position = newPosition;
            }
        }
    }
}

