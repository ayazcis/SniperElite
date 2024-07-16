using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed=10f;
	public Animator animator;
	private bool idleEnded = true;
	float endTime;

	private void Start()
	{
		targetPoint = 0;
	}

	private void Update()
	{
		if (transform.position == patrolPoints[targetPoint].position)
		{

			IdleToPatrolLogic();

		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed);
		transform.LookAt(patrolPoints[targetPoint].position);

		
	}
	void IdleToPatrolLogic()
	{
		if (idleEnded)
		{
			endTime = Idle();
		}

		if (Time.time > endTime)
		{
			animator.SetBool("Idle", false);
			IncreaseTargetpoint();
			idleEnded = true;
		}
	}

	void IncreaseTargetpoint()
	{
		if (targetPoint >= patrolPoints.Length-1)
		{
			targetPoint = 0;
		}
		else
		{
			targetPoint++;
		}
	}
	float Idle()
	{
		animator.SetBool("Idle", true);
		idleEnded = false;
		float idleTime =SetIdleTime();
		float startTime = Time.time;
		float endTime = startTime + idleTime;
		
		return endTime;
	}
	float SetIdleTime()
	{
		float time = Random.Range(2f,5f);
		return time;
	}


}
