using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody Rigidbody;
	float startTime;
	private GameObject player;
	public float speed = 1f;
	private GameObject fpsCamFollow;
	public float bulletLifeTime= 5f;

	private void OnEnable()
	{
		startTime = Time.time;
	}


	private void Awake()
	{
		
		Rigidbody = GetComponent<Rigidbody>();
		fpsCamFollow = GameObject.FindGameObjectWithTag("fpsFollowCam");

	}
	private void Start()
	{
		
	}
	void Update()
    {
		Rigidbody.velocity = fpsCamFollow.transform.forward * speed;

		CheckLifeTimeOfObject();

	}


	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("collided ");
		DeactivateGameObject();
		if (collision.gameObject.CompareTag("Enemy"))
		{
			//damage 
		}
	}

	private void CheckLifeTimeOfObject() 
	{
		if(Time.time - startTime > bulletLifeTime)
		{
			DeactivateGameObject();
			Debug.Log("time ");

		}
	}

	private void DeactivateGameObject()
	{
		gameObject.SetActive(false);
	}
}
