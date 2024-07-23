using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	private string animBoolName;
	float startTime;
	EnemyStateManager enemyStateManager;

	public IdleState(string animBoolName, EnemyStateManager enemyStateManager) : base(animBoolName, enemyStateManager)
	{
		this.animBoolName = animBoolName;
		this.enemyStateManager = enemyStateManager;
	}

	public override void EnterState()
	{
		enemyStateManager.animator.SetBool(animBoolName,true);
		startTime = Time.time;
	
	}

	public override void ExitState()
	{
		enemyStateManager.animator.SetBool(animBoolName, false);
	}

	public override void LogicUpdate()
	{
		if(Time.time >= startTime+ enemyStateManager.EnemyDataSO.idleTime)
		{ 
			enemyStateManager.ChangeState(enemyStateManager.movingState);
		}

	}


}
