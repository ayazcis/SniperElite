using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    Queue<GameObject> bulletQueue = new Queue<GameObject>();
    public GameObject bulletPrefab;
    public int maxBulletCount = 10;





    void Start()
    {
        for (int i = 0; i < maxBulletCount; i++)
        {
            GameObject gameObject = Instantiate(bulletPrefab);
            gameObject.SetActive(false);
            bulletQueue.Enqueue(gameObject);
        }
    }

    public GameObject SpawnBulletFromPool(Vector3 position, Vector3 PlayerRotation)
    {
        GameObject gameObject = bulletQueue.Dequeue();

		gameObject.transform.position = position;
        gameObject.transform.eulerAngles = new Vector3( -90,PlayerRotation.y,PlayerRotation.z );
		gameObject.SetActive(true);
        
        bulletQueue.Enqueue(gameObject);

        return gameObject;
    }
}
