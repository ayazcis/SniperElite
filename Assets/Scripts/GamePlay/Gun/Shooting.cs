using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class Shooting : MonoBehaviour
{
	public CameraShake cameraShake;
	public BulletObjectPool BulletObjectPool;

	public float damage = 10f;
	public float range = 1000f;
	public float force = 30f;
	public float Magnitude = 0.01f;

	public CinemachineVirtualCamera fpsCam;  
	public Transform bulletSpawnPoint;

	void Update()
	{
		Debug.DrawRay(fpsCam.transform.position, -transform.forward*100f, new Color(1, 1, 0),100000000f);
		if (Input.GetMouseButtonUp(0))
		{
			Shoot();
		}


	}
	void Shoot()
	{

		BulletObjectPool.SpawnBulletFromPool(bulletSpawnPoint.position, transform.eulerAngles);

		Debug.Log("Ateþ edildi: ");


		StartCoroutine(cameraShake.Shake(0.1f, Magnitude));
		if (Physics.Raycast(fpsCam.transform.position, -transform.forward , out RaycastHit hit, range))
		{
			


			
			if (hit.transform.gameObject.CompareTag("Enemy"))
			{
				
			}
			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * force);
			}

		}

	}
	
}
