using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
	private EnemyStateManager _enemyStateManager;
	private Enemy _enemy;

	public OnSlowMotionTime _onSlowMotionTime;

	public State currentState;

	public Animator animator;
	public IdleState idleState;
	public MovingState movingState;
	public DeadState deadState;

	public EnemyDataSO EnemyDataSO;


	private void Start()
	{
		_onSlowMotionTime = GameObject.FindGameObjectWithTag("OnSlowMotion").GetComponent<OnSlowMotionTime>();
		_enemyStateManager = GetComponent<EnemyStateManager>();
		_enemy = GetComponent<Enemy>();

		idleState = new IdleState("Idle", _enemyStateManager,_enemy);
		movingState = new MovingState("Moving", _enemyStateManager,_enemy);
		deadState = new DeadState("Dead", _enemyStateManager,_enemy);

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
