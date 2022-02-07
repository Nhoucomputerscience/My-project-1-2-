using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerTurn : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerStats enemyStats;
    public GameObject enemy;
    
    bool playerDodge = false;
    bool enemyDodge = false;
    bool playerTurn = true;
    float damage;
    float healAmount;
    float playerRandom;
    float enemyRandom;
    
    public Button attack;
    public Button spell;
    public Button potion;
    public Button spellHeal;
    public Text playerHPtext;
    public Text playerMPtext;
    public Text EnemyHPtext;

    public Text playerAction;  //which button was pressed?

    public Text playerDamage;  //how much player health changed by
    public Text enemyAction;  //did the enemy dodge?
    public Text enemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        enemyStats = enemy.GetComponent<PlayerStats>();

        attack.onClick.AddListener(() => AttackButton());
        spell.onClick.AddListener(() => SpellButton());
        potion.onClick.AddListener(() => PotionButton());
        spellHeal.onClick.AddListener(() => SpellHealButton());
    }

    // Update is called once per frame
    void Update()
    {
        playerHPtext.text = "HP: " + playerStats.getHP().ToString();
        playerMPtext.text = "MP: " + playerStats.getMP().ToString();
        EnemyHPtext.text = "Enemy HP: " + enemyStats.getHP().ToString();
        

    }


    void AttackButton()
    {
        playerAction.text = "The Player Attacked!";
        if (playerTurn)
        {
            //calculate if the attack was a success
            if (!EnemyDodge())
            {
                
                //the Enemy attack was successfull, calculate damage
                if (playerStats.getMeleeAttackDamage() - getEnemyDefense() > 0)
                {
                    damage = playerStats.getMeleeAttackDamage() - getEnemyDefense();
                }
                else damage = 1;

                enemyDamage.text = "Enemy was hurt " + damage.ToString();

                //apply damage
                enemyStats.setHP(-damage);
            }

            //TODO: delay the amount of seconds that the attack animation would take to play
            playerTurn = false;
            EnemyCounterAttack();
        }
    }

    void SpellButton()
    {
        //make sure we have enough mp
        if (playerTurn && playerStats.getMP()>=playerStats.SpellAttackCost())
        {
            //subtract the cost of the spell from mp
            playerStats.setMP(-playerStats.SpellAttackCost());
            playerAction.text = "The Player Casts a Spell!";

            if (!EnemyDodge())
            {
                //the Enemy attack was successfull, calculate damage
                if (playerStats.getSpellAttackDamage() - getEnemyDefense() > 0)
                {
                    damage = playerStats.getSpellAttackDamage() - getEnemyDefense();
                }
                else damage = 1;

                enemyDamage.text = "Enemy was hurt " + damage.ToString();

                //apply damage
                enemyStats.setHP(-damage);

            }
            //TODO: delay the amount of seconds that the attack animation would take to play
            playerTurn = false;
            EnemyCounterAttack();
        }
    }

    void PotionButton()
    {
        if (playerTurn)
        {
            //TODO: potions -=1;
            playerAction.text = "The Player Drank a Potion";

            healAmount = (5f + playerStats.getConstitution() * 5 + playerStats.getIntelligence() * 2);
            playerStats.setHP(healAmount);

            playerDamage.text = "Player was healed " + healAmount.ToString();

            //TODO: delay the amount of seconds that the attack animation would take to play
            playerTurn = false;
            EnemyCounterAttack();
        }
    }

    void SpellHealButton()
    {
        if (playerTurn && playerStats.getMP() >= playerStats.SpellHealCost())
        {
            playerAction.text = "The Player Healed!";
            //subtract the cost of the spell from mp
            playerStats.setMP(-playerStats.SpellHealCost());

            healAmount = (5f + playerStats.getConstitution() * 2 + playerStats.getIntelligence() * 5);
            playerStats.setHP(healAmount);

            playerDamage.text = "Player was healed " + healAmount.ToString();

            //TODO: delay the amount of seconds that the attack animation would take to play
            playerTurn = false;
            EnemyCounterAttack();
        }
    }

    bool PlayerDodge()
    {
        playerRandom = Random.Range(0f, 5f);
        enemyRandom = Random.Range(0f, 5f);
        
        if (playerStats.getAgility() + playerRandom > enemyStats.getAgility() + enemyRandom)
        {
            playerDodge = true;
            playerAction.text = "The Player Dodged!";
        }
        else playerDodge = false;
        

        return playerDodge;
    }

    bool EnemyDodge()
    {
        if (playerStats.getAgility() + Random.Range(0f, 5f) < enemyStats.getAgility() + Random.Range(0f, 5f))
        {
            enemyDodge = true;
            enemyAction.text = "The Enemy Dodged!";
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
            //the Enemy attack was successfull, calculate damage
            if (enemyStats.getMeleeAttackDamage() - getPlayerDefense() > 0)
            {
                damage = enemyStats.getMeleeAttackDamage() - getPlayerDefense();
            }
            else damage = 1;
            
            //apply damage
            playerStats.setHP(-damage);
            playerDamage.text = "Player was hurt by " + damage.ToString();
        }
        //TODO: delay the amount of seconds that the attack animation would take to play
        playerTurn = true;
    }
}