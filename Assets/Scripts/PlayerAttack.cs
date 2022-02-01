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
    bool playerDodge = false;
    bool enemyDodge = false;
    bool playerTurn = true;
    float damage;
    float agility;
    float enemyAgilty;
    float healAmount;


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
            if (!EnemyDodge())
            {
                //the Enemy attack was successfull, do damage
                if (playerStats.getMeleeAttackDamage() - getEnemyDefense() > 0)
                {
                    damage = playerStats.getMeleeAttackDamage() - getEnemyDefense();
                }
                else damage = 1;

                enemyHP -= damage;

            }
            //TODO: delay the amount of seconds that the attack animation would take to play
            EnemyCounterAttack();
        }
    }

    void SpellButton()
    {
        if (playerTurn)
        {
            //TODO: Subtract Mana Points
            playerTurn = false;
            if (!EnemyDodge())
            {
                //the Enemy attack was successfull, do damage
                if (playerStats.getSpellAttackDamage() - getEnemyDefense() > 0)
                {
                    damage = playerStats.getSpellAttackDamage() - getEnemyDefense();
                }
                else damage = 1;

                enemyHP -= damage;

            }
            //TODO: delay the amount of seconds that the attack animation would take to play
            EnemyCounterAttack();
        }
    }

    void PotionButton()
    {
        if (playerTurn)
        {
            //TODO: potions -=1;
            playerTurn = false;

            healAmount = (5f + playerStats.getConstitution() * 5 + playerStats.getIntelligence() * 2);
            playerStats.setHP(healAmount);



            //TODO: delay the amount of seconds that the attack animation would take to play
            EnemyCounterAttack();
        }
    }

    void SpellHealButton()
    {
        if (playerTurn)
        {
            //TODO: Subtract Mana Points
            playerTurn = false;

            healAmount = (5f + playerStats.getConstitution() * 2 + playerStats.getIntelligence() * 5);
            playerStats.setHP(healAmount);

            //TODO: delay the amount of seconds that the attack animation would take to play
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
        //TODO: calculate defense, 0 is for testing
        return 0f;
    }


    float getEnemyDefense()
    {
        //TODO: calculate defense, 0 is for testing
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

            playerStats.setHP(-damage);
            print("HP = " + playerStats.getHP());

        }
        //TODO: delay the amount of seconds that the attack animation would take to play
        playerTurn = true;
    }
}