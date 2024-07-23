using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedState : State
{
	private string animBoolName;
	EnemyStateManager enemyStateManager;
	private GameObject player;
	public DetectedState(string animBoolName, EnemyStateManager enemyStateManager) : base(animBoolName, enemyStateManager)
	{
		this.animBoolName = animBoolName;
		this.enemyStateManager = enemyStateManager;
		player =  GameObject.FindGameObjectWithTag("Player");
	}
	public override void EnterState()
	{
		enemyStateManager.animator.SetBool(animBoolName, true);
		

	}

	public override void ExitState()
	{
		enemyStateManager.animator.SetBool(animBoolName, false);
	}

	public override void LogicUpdate()
	{
		//if(Vector3.Distance(player.transform.position,enemyStateManager.transform.position)<5f)

	}
}
