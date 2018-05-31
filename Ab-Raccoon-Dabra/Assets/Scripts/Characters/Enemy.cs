using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{

    public LevelManager gameBoss;
    public Transform target;
    public int scoreWorth = 5;
    public float turnSpeed;
    public float viewRangeModifier = 5;
    public LayerMask obstacles;
    public float attackDelay;

    bool canAttack, timerReset;
    float attackDelayTimer;


    NavMeshAgent navMeshAgent;

    public EnemyType enemyType;

    public enum EnemyType
    {
        Mole, Bat
    }

    public Vector3 TargetDirection()
    {
        return target.position - transform.position;
    }
    public bool CanAttack()
    {
        if (attackDelayTimer < Time.time - attackDelay)
            canAttack = true;

        float sqrLen = TargetDirection().sqrMagnitude;
        if (sqrLen < navMeshAgent.stoppingDistance * navMeshAgent.stoppingDistance)
        {
            //Reset timer once
            if (!timerReset)
            {
                canAttack = false;
                attackDelayTimer = Time.time;
                timerReset = true;
            }
        }
        else
        {
            canAttack = false;
            timerReset = false;
        }
        
        return canAttack;
    }

    public bool CanSeeTarget()
    {

        if (Physics.Raycast(transform.position, TargetDirection(), navMeshAgent.stoppingDistance + viewRangeModifier, obstacles))
        {
            //if the player is behind an obstacle
            return false;
        }
        else
            return true;
    }

    private void Awake()
    {
        health = new Health(maxHealth);

        animControl = new AnimControl(GetComponentInChildren<Animator>());
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void Move()
    {
        if (!iceBuff && !stunBuff && target)
            navMeshAgent.SetDestination(target.position);
        else
            navMeshAgent.SetDestination(transform.position);
        
    }

    public void RotateTowardsTraget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(TargetDirection());
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed);
    }

    private void Update()
    {
        Move();
        if (CanSeeTarget())
        {
            RotateTowardsTraget();

            if (CanAttack())
            {
                AttackCall();
            }
        }
    }

    private void AttackCall()
    {
        // Debug.Log(gameObject.name + " attacking!");
        Attack(0);
    }

    protected override void DIE()
    {
        gameBoss.EnemyDeath(scoreWorth);
        base.DIE();
    }




}
