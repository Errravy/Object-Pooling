using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    normal,
    piercing,
    auto
}
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public Dictionary<BulletType, Queue<GameObject>> bullet = new Dictionary<BulletType, Queue<GameObject>>();
    public Pool bulletType;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Queue<GameObject> bulletQueue = new Queue<GameObject>();
        for (int i = 0; i < bulletType.size; i++)
        {
            GameObject obj = Instantiate(bulletType.bullet, transform);
            obj.SetActive(false);
            bulletQueue.Enqueue(obj);
        }
        bullet.Add(bulletType.bulletType, bulletQueue);
    }

    public void SpawnBullet(BulletType bulletType, Transform player)
    {
        GameObject objToSpawn = bullet[bulletType].Dequeue();
        objToSpawn.SetActive(true);
        objToSpawn.transform.position = player.position;
        objToSpawn.transform.rotation = player.rotation;
        bullet[bulletType].Enqueue(objToSpawn);
    }
}

[System.Serializable]
public class Pool
{
    public BulletType bulletType;
    public GameObject bullet;
    public int size;
}
