using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{

    public LevelManager gameBoss;
    public Transform target;
    public float turnSpeed;
    public int scoreWorth = 5;

    [SerializeField]
    float maxHealth;

    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        health = new Health(maxHealth);
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Move()
    {
         navMeshAgent.SetDestination(target.position);
    }

    private void Update()
    {
        Move();
    }

    protected override void DIE()
    {
        gameBoss.EnemyDeath(scoreWorth);
        base.DIE();
    }

}
