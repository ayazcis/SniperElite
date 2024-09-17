using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MovingState : State
{
	private Enemy _enemy;
	private EnemyStateManager _enemyStateManager;

	private Vector3[] _patrolPoints;

	private string _animBoolName;
	public int targetPoint = 0;
	



	public MovingState(string animBoolName, EnemyStateManager enemyStateManager, Enemy enemy) : base(animBoolName, enemyStateManager, enemy)
	{
		_animBoolName = animBoolName;
		_enemyStateManager = enemyStateManager;
		_enemy = enemy;
		_patrolPoints = new Vector3[3];
		_patrolPoints[0] = new Vector3(enemyStateManager.transform.position.x+ _enemyStateManager.EnemyDataSO.moveRange, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z);
		_patrolPoints[1] = new Vector3(enemyStateManager.transform.position.x - _enemyStateManager.EnemyDataSO.moveRange, enemyStateManager.transform.position.y, enemyStateManager.transform.position.z );
		_patrolPoints[2] = new Vector3(enemyStateManager.transform.position.x , enemyStateManager.transform.position.y, enemyStateManager.transform.position.z - (_enemyStateManager.EnemyDataSO.moveRange * 2));
	}

	public override void EnterState()
	{
		_enemyStateManager.animator.SetBool(_animBoolName, true);
		

	}


	public override void ExitState()
	{
		_enemyStateManager.animator.SetBool(_animBoolName, false);
	}

	public override void LogicUpdate()
	{
		if (_enemyStateManager.transform.position == _patrolPoints[targetPoint]  || _enemyStateManager._onSlowMotionTime.m_SlowMotion)
		{
			ChangeTargetPoint();
			_enemyStateManager.ChangeState(_enemyStateManager.idleState);

		}
		_enemyStateManager.transform.position = Vector3.MoveTowards(_enemyStateManager.transform.position, _patrolPoints[targetPoint], _enemyStateManager.EnemyDataSO.moveSpeed* Time.deltaTime);
		_enemyStateManager.transform.LookAt(_patrolPoints[targetPoint]);

		if (_enemy.IsDead())
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
