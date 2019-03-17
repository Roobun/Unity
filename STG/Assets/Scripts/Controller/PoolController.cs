using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public GameObject[]      objects;
    public int               pooledAmount;
    public bool              willGrow;

    private List<GameObject> pooledObjects;
    private GameObject       pooledObject;

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }

    public void NextObject()
    {
        DestroyAll();
        pooledObject = GetRandomObject();
        CreateNewPool();
    }

    public void DestroyAll()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {   
            Destroy(pooledObjects[i]);
        }
    }

    private void Start()
    {
        pooledObject = GetRandomObject();
        CreateNewPool();
    }

    private void CreateNewPool()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    private GameObject GetRandomObject()
    {
        return objects[Random.Range(0, objects.Length - 1)];
    }
}
