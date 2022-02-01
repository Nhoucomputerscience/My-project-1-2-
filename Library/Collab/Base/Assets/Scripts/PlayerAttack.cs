using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerStats enemyStats;
    public GameObject enemy;
    float hp;
    float enemyHP;
    bool playerDodge =false;
    bool enemyDodge = false;
    bool playerTurn = true;
    float damage;
    float agility;
    float enemyAgilty;


    // Start is called before the first frame update
    void Start()
    {
        
        playerStats = GetComponent<PlayerStats>();
        enemyStats = enemy.GetComponent<PlayerStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void AttackButton()
    {
        if (playerTurn)
        {
            playerTurn = false;
            if(!EnemyDodge())
            {
                //the Enemy attack was successfull, do damage
                if (playerStats.getMeleeAttackDamage() - getEnemyDefense() > 0)
                {
                    damage = playerStats.getMeleeAttackDamage() - getEnemyDefense();
                }
                else damage = 1;
                
                enemyHP -= damage;
                
            } 
            EnemyCounterAttack();
        }
    }

    bool PlayerDodge()
    {
        
        if (agility + Random.Range(0f, 5f) > enemyAgilty + Random.Range(0f, 5f))
        {
            playerDodge = true;
        }
        else playerDodge = false;

    return playerDodge;
    }

    bool EnemyDodge()
    {
        if (agility + Random.Range(0f, 5f) < enemyAgilty + Random.Range(0f, 5f))
        {
            enemyDodge = true;
        }
        else enemyDodge = false;

        return enemyDodge;
    }



    float getPlayerDefense()
    {
        return 0f;
    }


    float getEnemyDefense()
    {
        return 0f;
    }

    void EnemyCounterAttack()
    {
        playerTurn = false;
        if (!PlayerDodge())
        {
            //the Enemy attack was successfull, do damage
            if (enemyStats.getMeleeAttackDamage() - getPlayerDefense() > 0)
            {
                damage = enemyStats.getMeleeAttackDamage() - getPlayerDefense();
            }
            else damage = 1;

            hp -= damage;

        }
        playerTurn = true;
    }
}
