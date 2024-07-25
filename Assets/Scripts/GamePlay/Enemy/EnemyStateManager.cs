using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
	private EnemyStateManager _enemyStateManager;
	private EnemyHealth _enemyHealth;

	public State currentState;

	public Animator animator;
	public IdleState idleState;
	public MovingState movingState;
	public DeadState deadState;

	public EnemyDataSO EnemyDataSO;


	private void Start()
	{
		_enemyStateManager = GetComponent<EnemyStateManager>();
		_enemyHealth = GetComponent<EnemyHealth>();

		idleState = new IdleState("Idle", _enemyStateManager,_enemyHealth);
		movingState = new MovingState("Moving", _enemyStateManager,_enemyHealth);
		deadState = new DeadState("Dead", _enemyStateManager,_enemyHealth);

		currentState = idleState;
		currentState.EnterState();
	}
	private void Update()
	{
		currentState.LogicUpdate();
	}

	public void ChangeState(State state)
	{
		currentState.ExitState();
		currentState = state;
		currentState.EnterState();
	}
}
