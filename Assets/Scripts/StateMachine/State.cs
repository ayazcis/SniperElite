using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class State 
{
	string animBoolName;
	EnemyStateManager enemyStateManager;

	public State(string animBoolName , EnemyStateManager enemyStateManager)
	{
		this.animBoolName = animBoolName;
		this.enemyStateManager = enemyStateManager;
	}

	public virtual void EnterState()
	{
		enemyStateManager.animator.SetBool(animBoolName, true);
	}
	public virtual void LogicUpdate()
	{

	}

	public virtual void ExitState()
	{

	}

}
