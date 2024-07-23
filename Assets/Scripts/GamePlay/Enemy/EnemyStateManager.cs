using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
	private EnemyStateManager enemyStateManager;
	public State currentState;
	public Animator animator;
	public IdleState idleState;
	public DetectedState detectedState;
	public MovingState movingState;
	public EnemyDataSO EnemyDataSO;


	private void Start()
	{
		enemyStateManager = GetComponent<EnemyStateManager>();

		idleState = new IdleState("Idle", enemyStateManager);
		movingState = new MovingState("Moving", enemyStateManager);
		detectedState = new DetectedState("Detected",enemyStateManager);

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
