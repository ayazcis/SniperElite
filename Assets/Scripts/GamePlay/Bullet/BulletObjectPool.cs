using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    private Queue<GameObject> _bulletQueue = new Queue<GameObject>();

    public GameObject bulletPrefab;
    public Transform bulletSpawnReferancePoint;

	public int maxBulletCount = 10;





    void Start()
    {
        for (int i = 0; i < maxBulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);

            bullet.SetActive(false);
            _bulletQueue.Enqueue(bullet);
        }
    }

    public GameObject SpawnBulletFromPool(Vector3 position, Vector3 PlayerRotation)
    {
		GameObject bullet = _bulletQueue.Dequeue();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Call(bulletSpawnReferancePoint.transform.forward);
		bullet.transform.position = position;
		bullet.transform.eulerAngles = new Vector3(-90, PlayerRotation.y, PlayerRotation.z);
		bullet.SetActive(true);

		_bulletQueue.Enqueue(gameObject);

		return bullet;
	}
}
