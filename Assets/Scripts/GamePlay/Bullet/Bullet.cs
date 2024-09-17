using System.Collections;
using Cinemachine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Rigidbody _rb;
	private Vector3 _bulletDirection;
	private CinemachineVirtualCamera _cinemachineVirtualCamera;
	public AnimationCurve speedCurve;
	private ParticleSystem _particleSystem;
	private SkinnedMeshRenderer _skinnedMeshRenderer;

	private float _startTime;
	public float bulletHealth = 5f;
	public float maxSpeed = 0.5f;
	public float bulletLifeTime = 5f;

	private OnSlowMotionTime _onSlowMotionTime;
	private bool _isSlowMotionActive;
	private bool _isHit;

	private void Awake()
	{
		_skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
		_particleSystem = GetComponentInChildren<ParticleSystem>();	
		_onSlowMotionTime = GameObject.FindGameObjectWithTag("OnSlowMotion").GetComponent<OnSlowMotionTime>();
		_rb = GetComponent<Rigidbody>();
		_cinemachineVirtualCamera = GameObject.FindGameObjectWithTag("BulletCam").GetComponent<CinemachineVirtualCamera>();
	}

	public void Call(Vector3 direction)
	{
		_bulletDirection = direction;
		_startTime = Time.time;
	}

	void Update()
	{
		Debug.DrawRay(transform.position, _bulletDirection * 55555, Color.red, 5555f);
		Move();
		//RayShoot();
		CheckLifeTimeOfObject();
	}

	private void Move()
	{
		if (!_isHit)
		{
			float elapsedTime = Time.time - _startTime;
			float curveTime = elapsedTime / bulletLifeTime;
			float currentSpeed = speedCurve.Evaluate(curveTime) * maxSpeed;
			_rb.velocity = _bulletDirection * currentSpeed;
		}
	}

	private void CheckLifeTimeOfObject()
	{
		if (Time.time - _startTime > bulletLifeTime)
		{
			DeactivateGameObject();
			Debug.Log("time ");
		}
	}

	public void RayShoot()
	{
		if (Physics.Raycast(transform.position, _bulletDirection, out RaycastHit hit, 500) && hit.transform.gameObject.CompareTag("Enemy"))
		{
			_isHit = true;
			float distanceToEnemy = Vector3.Distance(transform.position, hit.transform.position);
			float travelTime = distanceToEnemy / (maxSpeed/2);
			gameObject.SetActive(true);
			StartCoroutine(HandleSlowMotionEffect(hit.transform.gameObject, travelTime));
			BulletCollidedWithEnemy(hit.transform.gameObject);
			_onSlowMotionTime.SetEnemySpeed(0.1f);
		}
	}

	private void BulletCollidedWithEnemy(GameObject enemy)
	{
		_cinemachineVirtualCamera.Follow = this.gameObject.transform;
		_cinemachineVirtualCamera.LookAt = this.gameObject.transform;
		_cinemachineVirtualCamera.Priority = 13;

		Debug.Log("Enemy hit");
	}

	private void DamageEnemy(GameObject enemy)
	{
		Enemy _enemy = enemy.GetComponent<Enemy>();
		_enemy.TakeDamage(bulletHealth);
	}

	private void DeactivateGameObject() => gameObject.SetActive(false);

	private IEnumerator HandleSlowMotionEffect(GameObject enemy, float duration)
	{
		_skinnedMeshRenderer.enabled = true;

		_isSlowMotionActive = true;
		float elapsedTime = 0f;
		_onSlowMotionTime.m_SlowMotion = true;
		while (elapsedTime < duration)
		{
			float t = elapsedTime / duration;
			float currentSpeed = speedCurve.Evaluate(t) * maxSpeed;
			_rb.velocity = _bulletDirection * currentSpeed;

			elapsedTime += Time.deltaTime;
			yield return null;
		}

		_skinnedMeshRenderer.enabled = false;
		_rb.velocity = Vector3.zero;

		_particleSystem.Play();

		_onSlowMotionTime.SetBackEnemySpeed();
		DamageEnemy(enemy);

		_isSlowMotionActive = false;
		_onSlowMotionTime.m_SlowMotion = false;
		//yield return new WaitForSeconds(1);

		_cinemachineVirtualCamera.Priority = 10;

		DeactivateGameObject();
	}
}
