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
	EnemyHealth EnemyHealth;

	public State(string animBoolName , EnemyStateManager enemyStateManager, EnemyHealth enemyHealth)
	{
		this.animBoolName = animBoolName;
		this.enemyStateManager = enemyStateManager;
		this.EnemyHealth = enemyHealth;
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
