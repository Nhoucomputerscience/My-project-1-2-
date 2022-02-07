using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    float strength;
    float stamina;
    float constitution;
    float agility;
    float intelligence;
    float luck;
    public Button StrengthUp;
    public Button StrengthDown;
    public Button submit;

    float tempStrength;
    

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
    float spellAttackCost;
    float itemDiscovery;
    float itemDiscoveredQuality;
    float equippedWeaponWeight;
    float classHP;
    float spellHealCost;




    // Start is called before the first frame update
    void Start()
    {
        createPlayer(5, 5, 5, 5, 5, 5);
        print("Strength: " + getStrength());
        

        StrengthUp.onClick.AddListener(() => ChangeBaseStat(ref tempStrength, 1));
        submit.onClick.AddListener(() => submitStatChangeButton());
        

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

    public float getStrength()
    {
        return strength;
    }

    public float getTempStrength()
    {
        tempStrength += strength;
        return tempStrength;
    }

    public void TempIncreaseStrength()
    {
        tempStrength++;
        print(tempStrength);
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
        if (hp > maxHP)
        {
            hp = maxHP;
        }
    }

    public float getHP()
    {
        return hp;
    }

    void setMaxMP()
    {
        //TODO: we need to set class HP at some point
        //calculate what full health is
        maxMP = (5 * intelligence);
    }

    void setInitialMP()
    {
        //start with full health
        mp = maxMP;
    }

    public void setMP(float amount)
    {
        //adjust health as we play the game
        mp += amount;
    }

    public float getMP()
    {
        return mp;
    }

    public float SpellAttackCost()
    {
        //TODOD: create some formula instead of hard code in a cost.
        spellAttackCost = 5;

        return spellAttackCost;
    }

    public float SpellHealCost()
    {
        //TODOD: create some formula instead of hard code in a cost.
        spellHealCost = 7;

        return spellHealCost;
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

    public void ChangeBaseStat(ref float baseStat, float amount)
    {
        
        baseStat += amount;

        if (baseStat < 0)
        { baseStat = 0; }

        print(baseStat);


    }

    public void submitStatChangeButton()
    {


        strength += tempStrength;
        tempStrength = 0;
        setMeleeAttackDamage();
        print(strength);


    }



}