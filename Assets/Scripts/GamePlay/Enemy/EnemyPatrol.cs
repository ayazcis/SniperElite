using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed=10f;


	private void Start()
	{
		targetPoint = 0;
	}

	private void Update()
	{
		if (transform.position == patrolPoints[targetPoint].position)
		{
			IncreaseTargetpoint();
		}
		transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed);

		
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


}
