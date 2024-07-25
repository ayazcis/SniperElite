using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
	private string _animBoolName;

	private EnemyStateManager _enemyStateManager;
	private EnemyHealth _enemyHealth;

	public DeadState(string animBoolName, EnemyStateManager enemyStateManager, EnemyHealth enemyHealth) : base(animBoolName, enemyStateManager, enemyHealth)
	{
		_animBoolName = animBoolName;
		_enemyStateManager = enemyStateManager;
		_enemyHealth = enemyHealth;
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

	}

}
