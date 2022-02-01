using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float strength;
    float stamina;
    float constitution;
    float agility;
    float intelligence;
    float luck;

    float meleeAttackDamage;
    float maxLoad;
    float moveSpeed;
    float attackStaminaCost;
    float maxHP;
    float hp;
    float rangedAttackDamage;
    float attackSpeed;
    float critChance;
    float dodge;
    float maxMP;
    float mp;
    float spellAttackDamage;
    float itemDiscovery;
    float itemDiscoveredQuality;
    float equippedWeaponWeight;
    float classHP;



    // Start is called before the first frame update
    void Start()
    {
        createPlayer(5, 5, 5, 5, 5, 5);
        setMeleeAttackDamage();
        setMaxLoad();
        setMoveSpeed();
        setAttackStaminaCost();
        setMaxHP();
        setInitialHP();
        setSpellAttackDamage();
        setItemDiscovery();
        setItemDiscoveredQuality();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void createPlayer(float strength, float stamina, float constitution, float agility, float intelligence, float luck)
    {
        this.strength = strength;
        this.stamina = stamina;
        this.constitution = constitution;
        this.agility = agility;
        this.intelligence = intelligence;
        this.luck = luck;

        if (strength + stamina + constitution + agility + intelligence + luck > 30)
        {
            //TODO don't allow over 30 points in a player when created.

        }

    }

    public float getStrength()
    {
        return strength;
    }

    public float getStamina()
    {
        return stamina;
    }
    public float getConstitution()
    {
        return constitution;
    }
    public float getAgility()
    {
        return agility;
    }
    public float getIntelligence()
    {
        return intelligence;
    }
    public float getLuck()
    {
        return luck;
    }
    void setMeleeAttackDamage()
    {
        meleeAttackDamage = 5 * strength;
    }

    public float getMeleeAttackDamage()
    {
        return meleeAttackDamage;
    }

    void setMaxLoad()
    {
        maxLoad = 5 * strength + 3 * stamina + 3 * constitution;
    }

    public float getMaxLoad()
    {
        return maxLoad;
    }

    void setMoveSpeed()
    {
        moveSpeed = 3 * stamina + 3 * agility + 3 * constitution;
    }

    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    void setAttackStaminaCost()
    {
        attackStaminaCost = equippedWeaponWeight - (.5f * agility);
        if (attackStaminaCost < 1)
        {
            attackStaminaCost = 1;
        }
    }

    public float getAttackStaminaCost()
    {
        return attackStaminaCost;
    }

    void setMaxHP()
    {
        //TODO: we need to set class HP at some point
        //calculate what full health is
        maxHP = (5 * constitution) + classHP;
    }

    void setInitialHP()
    {
        //start with full health
        hp = maxHP;
    }

    public void setHP(float amount)
    {
        //adjust health as we play the game
        hp += amount;
    }

    public float getHP()
    {
        return hp;
    }


    void setSpellAttackDamage()
    {
        spellAttackDamage = 5 * intelligence;
    }

    public float getSpellAttackDamage()
    {
        return spellAttackDamage;
    }

    void setItemDiscovery()
    {
        itemDiscovery = (5 * intelligence) + (3 * luck);

    }

    public float getItemDiscovery()
    {
        return itemDiscovery;
    }

    void setItemDiscoveredQuality()
    {
        itemDiscoveredQuality = ((5 * luck) + intelligence);
    }

    public float getItemDiscoveredQuality()
    {
        return itemDiscoveredQuality;
    }

    void ChangeBaseStat(string BaseStat)
    {
        //Concoct string and float;

    }
        
}