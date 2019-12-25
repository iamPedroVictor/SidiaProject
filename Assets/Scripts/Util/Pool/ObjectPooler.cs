using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public StringReference tag;
        public GameObject prefab;
        public IntReference size;
    }

    
    public static ObjectPooler Instance;
    [SerializeField]
    private List<Pool> pools;
    [SerializeField]
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            BuildPool(pool);
        }
    }

    public void NewPool(GameObject prefab, StringReference poolTag, IntReference size)
    {
        Pool newPool = new Pool();
        newPool.prefab = prefab;
        newPool.tag = poolTag;
        newPool.size = size;
        pools.Add(newPool);
        BuildPool(newPool);
    }

    private void BuildPool(Pool pool)
    {
        GameObject parentPool = new GameObject(string.Format("Pool {0}", pool.tag.Value));
        parentPool.transform.SetParent(this.transform);
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.size.Value; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.transform.SetParent(parentPool.transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        poolDictionary.Add(pool.tag.Value, objectPool);
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Não existe uma pool com a tag: " + tag);
            return null;
        }
        GameObject obj = poolDictionary[tag].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;
        obj.transform.rotation = rotation;

        IPoolObject poolObject = obj.GetComponent<IPoolObject>();

        if (poolObject != null)
        {
            poolObject.OnSpawn();
        }

        return obj;
    }

    public void ReturnObjectToPool(string tag, GameObject go)
    {
        poolDictionary[tag].Enqueue(go);
        go.SetActive(false);
    }

}
