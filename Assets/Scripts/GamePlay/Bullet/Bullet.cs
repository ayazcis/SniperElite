using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody _rb;
	private Vector3 _bulletDirection;

	private float _startTime;
	public float bulletHealth = 5f;
	public float speed = 1f;
	public float bulletLifeTime= 5f;


	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		//_bulletSpawnReferancePoint = GameObject.FindGameObjectWithTag("fpsReferanceTransform");
	}
	public void Call(Vector3 Direction)
	{
		_bulletDirection = Direction;
		_startTime = Time.time;
	}
	void Update()
    {
		Debug.DrawRay(transform.position, _bulletDirection * 55555, Color.red,5555f);
		Move();

		CheckLifeTimeOfObject();

	}
	private void OnEnable() 
	{
		
	}


	private void Move()
	{
		//transform.Translate(_bulletDirection * speed * Time.deltaTime);
		//transform.position += _bulletSpawnPoint.transform.forward * speed * Time.deltaTime;
		_rb.velocity = _bulletDirection * speed * Time.deltaTime;
	}

	// TODO: yapýlacaklar
	#region bullet deactivate checks
	private void CheckLifeTimeOfObject()
	{
		 
		if (Time.time - _startTime > bulletLifeTime)
		{
			DeactivateGameObject();
			Debug.Log("time ");

		}
	}
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("collided "+ other.gameObject.name);

		if (other.gameObject.CompareTag("Enemy"))
		{
			BulletCollidedWithEnemy(other.gameObject);
		}
	}
	private void BulletCollidedWithEnemy(GameObject Enemy)
	{
		Debug.Log("enemy vuruldu");
		DeactivateGameObject();
		DamageEnemy(Enemy);
	}
	#endregion


	private void DeactivateGameObject() => gameObject.SetActive(false);
	
	public void DamageEnemy(GameObject Enemy)
	{
		EnemyHealth _enemyHealth = Enemy.GetComponent<EnemyHealth>();
		_enemyHealth.health -= bulletHealth;
	}
}
