using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
        public bool shouldExpand = true;
    }

    public List<ObjectPoolItem> itemsToPool;

    public List<GameObject> pooledObjects;    

    public static ObjectPooler SharedInstance;

    

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        foreach(ObjectPoolItem items in itemsToPool)
        {
            for(int i = 0; i< items.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(items.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }

        //for(int i = 0; i < amountToPool; i++)
        //{
        //    GameObject obj = (GameObject)Instantiate(objectToPool);
        //    obj.SetActive(false);
        //    pooledObjects.Add(obj);
        //}
    }

    public GameObject GetPooledObject(string tag)
    {

        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;


        ////1
        //for(int i = 0;i < pooledObjects.Count;i++)
        //{
        //    //2
        //    if(!pooledObjects[i].activeInHierarchy)
        //    {
        //        return pooledObjects[i];
        //    }
        //}

        ////return null;
        //if(shouldExpand)
        //{
        //    GameObject obj = (GameObject)Instantiate(objectToPool);
        //    obj.SetActive(false);
        //    pooledObjects.Add(obj);
        //    return obj;
        //}
        //else
        //{
        //    return null;
        //}
    }
}
