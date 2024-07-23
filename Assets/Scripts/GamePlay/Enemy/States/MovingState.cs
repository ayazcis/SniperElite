using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovingState : State
{
	private string animBoolName;
	Vector3[] patrolPoints;
	public int targetPoint=0;
	EnemyStateManager enemyStateManager;


	public MovingState(string animBoolName, EnemyStateManager enemyStateManager) : base(animBoolName, enemyStateManager)
	{
		this.animBoolName = animBoolName;
		this.enemyStateManager = enemyStateManager;
		patrolPoints = new Vector3[3];
		patrolPoints[0] = new Vector3(enemyStateManager.transform.position.x+2f, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z+2f); ///deðiþtir
		patrolPoints[1] = new Vector3(enemyStateManager.transform.position.x - 3f, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z - 3f);
		patrolPoints[2] = new Vector3(enemyStateManager.transform.position.x + 4f, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z - 12f);
	}

	public override void EnterState()
	{
		Debug.Log(targetPoint);
		enemyStateManager.animator.SetBool(animBoolName, true);
		/*patrolPoints[0] = new Vector3(-10.6199999f, -0.600000024f, -46.5900002f); ///deðiþtir
		patrolPoints[1] = new Vector3(-5.46000004f, -0.600000024f, -34.9199982f);
		patrolPoints[2] = new Vector3(-2.76999998f, -0.600000024f, -52.7099991f);*/

	}


	public override void ExitState()
	{
		enemyStateManager.animator.SetBool(animBoolName, false);
	}

	public override void LogicUpdate()
	{
		if (enemyStateManager.transform.position == patrolPoints[targetPoint])
		{
			ChangeTargetPoint();
			enemyStateManager.ChangeState(enemyStateManager.idleState);

		}
		enemyStateManager.transform.position = Vector3.MoveTowards(enemyStateManager.transform.position, patrolPoints[targetPoint], enemyStateManager.EnemyDataSO.moveSpeed* Time.deltaTime);
		enemyStateManager.transform.LookAt(patrolPoints[targetPoint]);
	}
	void ChangeTargetPoint()
	{
		int tmp;
		do
		{
			tmp = UnityEngine.Random.Range(0, patrolPoints.Length);
		} while (tmp == targetPoint);
		targetPoint = tmp;
		
	}
	
}
