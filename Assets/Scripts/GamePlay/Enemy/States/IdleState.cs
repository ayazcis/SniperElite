using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	private string _animBoolName;
	private float _startTime;

	private EnemyStateManager _enemyStateManager;
	private EnemyHealth _enemyHealth;

	public IdleState(string animBoolName, EnemyStateManager enemyStateManager, EnemyHealth enemyHealth) : base(animBoolName, enemyStateManager, enemyHealth)
	{
		_animBoolName = animBoolName;
		_startTime = Time.time;
		_enemyStateManager = enemyStateManager;
		_enemyHealth = enemyHealth;
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
		if(Time.time >= _startTime+ _enemyStateManager.EnemyDataSO.idleTime)
		{ 
			_enemyStateManager.ChangeState(_enemyStateManager.movingState);
		}
		if (_enemyHealth.dead)
		{
			_enemyStateManager.ChangeState(_enemyStateManager.deadState);
		}
	}


}
