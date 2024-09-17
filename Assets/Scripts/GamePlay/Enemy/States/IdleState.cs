using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : State
{
	private string _animBoolName;
	private float _startTime;

	private EnemyStateManager _enemyStateManager;
	private Enemy _enemy;


	public IdleState(string animBoolName, EnemyStateManager enemyStateManager, Enemy enemy) : base(animBoolName, enemyStateManager, enemy)
	{
		_animBoolName = animBoolName;
		_startTime = Time.time;
		_enemyStateManager = enemyStateManager;
		_enemy = enemy;
	}

	public override void EnterState()
	{
		_enemyStateManager.animator.SetBool(_animBoolName,true);
		_startTime = Time.time;
	
	}

	public override void ExitState()
	{
		_enemyStateManager.animator.SetBool(_animBoolName, false);
	}

	public override void LogicUpdate()
	{
		if(Time.time >= _startTime+ _enemyStateManager.EnemyDataSO.idleTime && !_enemyStateManager._onSlowMotionTime.m_SlowMotion)
		{ 
			_enemyStateManager.ChangeState(_enemyStateManager.movingState);
		}
		if (_enemy.IsDead() && !_enemyStateManager._onSlowMotionTime.m_SlowMotion )
		{
			_enemyStateManager.ChangeState(_enemyStateManager.deadState);
		}
	}


}
