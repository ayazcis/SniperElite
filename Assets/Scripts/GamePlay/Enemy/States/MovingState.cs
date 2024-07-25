using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovingState : State
{
	private EnemyHealth _enemyHealth;
	private EnemyStateManager _enemyStateManager;

	private Vector3[] _patrolPoints;

	private string _animBoolName;
	public int targetPoint = 0;
	



	public MovingState(string animBoolName, EnemyStateManager enemyStateManager, EnemyHealth enemyHealth) : base(animBoolName, enemyStateManager, enemyHealth)
	{
		_animBoolName = animBoolName;
		_enemyStateManager = enemyStateManager;
		_enemyHealth = enemyHealth;
		_patrolPoints = new Vector3[3];
		_patrolPoints[0] = new Vector3(enemyStateManager.transform.position.x+2f, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z+2f); ///deðiþtir
		_patrolPoints[1] = new Vector3(enemyStateManager.transform.position.x - 3f, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z - 3f);
		_patrolPoints[2] = new Vector3(enemyStateManager.transform.position.x + 4f, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z - 12f);
	}

	public override void EnterState()
	{
		Debug.Log(targetPoint);
		_enemyStateManager.animator.SetBool(_animBoolName, true);
		

	}


	public override void ExitState()
	{
		_enemyStateManager.animator.SetBool(_animBoolName, false);
	}

	public override void LogicUpdate()
	{
		if (_enemyStateManager.transform.position == _patrolPoints[targetPoint])
		{
			ChangeTargetPoint();
			_enemyStateManager.ChangeState(_enemyStateManager.idleState);

		}
		_enemyStateManager.transform.position = Vector3.MoveTowards(_enemyStateManager.transform.position, _patrolPoints[targetPoint], _enemyStateManager.EnemyDataSO.moveSpeed* Time.deltaTime);
		_enemyStateManager.transform.LookAt(_patrolPoints[targetPoint]);

		if (_enemyHealth.dead)
		{
			_enemyStateManager.ChangeState(_enemyStateManager.deadState);
		}
	}
	void ChangeTargetPoint()
	{
		int tmp;
		do
		{
			tmp = UnityEngine.Random.Range(0, _patrolPoints.Length);
		} while (tmp == targetPoint);
		targetPoint = tmp;
		
	}
	
}
