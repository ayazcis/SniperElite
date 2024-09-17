using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
	private string _animBoolName;

	private EnemyStateManager _enemyStateManager;
	private Enemy _enemy;
	private CapsuleCollider _capsuleCollider;

	public DeadState(string animBoolName, EnemyStateManager enemyStateManager, Enemy enemy) : base(animBoolName, enemyStateManager, enemy)
	{
		_animBoolName = animBoolName;
		_enemyStateManager = enemyStateManager;
		_enemy = enemy;
		_capsuleCollider = enemyStateManager.GetComponent<CapsuleCollider>();
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
        if (_enemyStateManager._onSlowMotionTime.m_SlowMotion)
        {
			_enemyStateManager.ChangeState(_enemyStateManager.idleState);
		}

    }

}
