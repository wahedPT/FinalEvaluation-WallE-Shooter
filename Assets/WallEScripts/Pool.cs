using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItems
{
    public GameObject prefab;
    public int amount;

}
public class Pool : MonoBehaviour
{
    public static Pool instance;
    public List<PoolItems> items;
    public List<GameObject> poolObjects;
    public float bulletSpeed;
    public int bulletCount = 50;

    private void Awake()
    {


        instance = this;



    }
    // Start is called before the first frame update
    void Start()
    {
        poolObjects = new List<GameObject>();
        foreach (PoolItems objectitems in items)
        {
            for (int i = 0; i < objectitems.amount; i++)
            {
                GameObject BulletRef = Instantiate(objectitems.prefab);

                BulletRef.SetActive(false);
                poolObjects.Add(BulletRef);

            }
        }
    }
    public GameObject Get(string tag)
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy && poolObjects[i].tag == tag)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
