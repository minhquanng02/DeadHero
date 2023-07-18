using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool;

    public Transform spawnedObjectsParent;


    [SerializeField] private GameObject objectPrefabs;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        CreateObject();
    }

    public void CreateObject()
    {
        CreateObjectParentIfNeeded();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectPrefabs);
            obj.name = transform.root.name + "_" + objectPrefabs.name + "_" + pooledObjects.Count;
            obj.transform.SetParent(spawnedObjectsParent);


            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + objectPrefabs.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
                spawnedObjectsParent = parentObject.transform;
            else
            {
                spawnedObjectsParent = new GameObject(name).transform;
            }

        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
