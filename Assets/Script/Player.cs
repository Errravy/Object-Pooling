using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] BulletType bulletType;

    private void Start()
    {
        StartCoroutine(Shoot());
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {


        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            ObjectPool.instance.SpawnBullet(bulletType, transform);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
