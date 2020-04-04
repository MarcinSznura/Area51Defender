using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrademenu : MonoBehaviour
{
    
    [Header("Player stats")]
    [SerializeField] int playerFireRate;
    [SerializeField] int playerDamage;
    [SerializeField] int playerMultishot;
    [SerializeField] int playerRecoilReduction;

    [SerializeField] int ammoCriticalHit;
    [SerializeField] int ammoExplosive;
    [SerializeField] int ammoIncendiary;

    [SerializeField] int baseSquadSize;
    [SerializeField] int baseFireRate;
    [SerializeField] int baseDamage;
    [SerializeField] int baseDrones;
    [SerializeField] int baseWires;
    [SerializeField] int baseAirStrike;
    [SerializeField] int baseNapalm;

    [Header("Skills text")]
    [SerializeField] TextMeshProUGUI stat_playerFireRateText;
    [SerializeField] TextMeshProUGUI stat_playerDamageText;
    [SerializeField] TextMeshProUGUI stat_playerMultishotText;
    [SerializeField] TextMeshProUGUI stat_playerRecoilReductionText;

    [SerializeField] TextMeshProUGUI baseSquadText;
    [SerializeField] TextMeshProUGUI baseFireRateText;
    [SerializeField] TextMeshProUGUI baseDamageText;
    [SerializeField] TextMeshProUGUI baseDronesText;
    [SerializeField] TextMeshProUGUI baseWiresText;
    [SerializeField] TextMeshProUGUI baseAirStrikeText;
    [SerializeField] TextMeshProUGUI baseNapalmText;

    [SerializeField] TextMeshProUGUI ammoCritText;
    [SerializeField] TextMeshProUGUI ammoIncText;
    [SerializeField] TextMeshProUGUI ammoExplText;

    [Header("Skill cost text")]
    [SerializeField] TextMeshProUGUI cost_baseSquadText;
    [SerializeField] TextMeshProUGUI cost_baseFireRateText;
    [SerializeField] TextMeshProUGUI cost_baseDamageText;
    [SerializeField] TextMeshProUGUI cost_baseDronesText;
    [SerializeField] TextMeshProUGUI cost_baseWiresText;
    [SerializeField] TextMeshProUGUI cost_baseAirStrikeText;
    [SerializeField] TextMeshProUGUI cost_baseNapalmText;

    [SerializeField] TextMeshProUGUI cost_playerFireRateText;
    [SerializeField] TextMeshProUGUI cost_playerDamageText;
    [SerializeField] TextMeshProUGUI cost_playerMultishotText;
    [SerializeField] TextMeshProUGUI cost_playerRecoilReductionText;

    [SerializeField] TextMeshProUGUI cost_ammoCritText;
    [SerializeField] TextMeshProUGUI cost_ammoIncText;
    [SerializeField] TextMeshProUGUI cost_ammoExplText;

    SkillCost skillCost;

    private int exp = 0;
    [SerializeField] int lang;


    private void Start()
    {
        skillCost = GetComponent<SkillCost>();
        SetAllSkillText();
        lang = FindObjectOfType<MainMenu>().language;
    }

    private void SetAllSkillText()
    {
        

        stat_playerFireRateText.text = playerFireRate.ToString();
        stat_playerDamageText.text = playerDamage.ToString();
        stat_playerMultishotText.text = playerMultishot.ToString();
        stat_playerRecoilReductionText.text = playerRecoilReduction.ToString();

        cost_playerFireRateText.text = skillCost.CostOfplayerFireRate(playerFireRate).ToString();
        cost_playerDamageText.text = skillCost.CostOfplayerDamage(playerDamage).ToString();
        cost_playerMultishotText.text = skillCost.CostOfplayerMultishot(playerMultishot).ToString();
        cost_playerRecoilReductionText.text = skillCost.CostOfplayerRecoilReduction(playerRecoilReduction).ToString();

        baseSquadText.text = baseSquadSize.ToString();
        baseFireRateText.text = baseFireRate.ToString();
        baseDamageText.text = baseDamage.ToString();
        baseDronesText.text = baseDrones.ToString();
        baseWiresText.text = baseWires.ToString();
        baseAirStrikeText.text = baseAirStrike.ToString();
        baseNapalmText.text = baseNapalm.ToString();

        cost_baseSquadText.text = skillCost.CostOfbaseSquadSize(baseSquadSize).ToString();
        cost_baseFireRateText.text = skillCost.CostOfbaseFireRate(baseFireRate).ToString();
        cost_baseDamageText.text = skillCost.CostOfbaseDamage(baseDamage).ToString();
        cost_baseDronesText.text = skillCost.CostOfbaseDrones(baseDrones).ToString();
        cost_baseWiresText.text = skillCost.CostOfbaseWires(baseWires).ToString();
        cost_baseAirStrikeText.text = skillCost.CostOfbaseAirStrike(baseAirStrike).ToString();
        cost_baseNapalmText.text = skillCost.CostOfbaseNapalm(baseNapalm).ToString();

        ammoCritText.text = ammoCriticalHit.ToString();
        ammoIncText.text = ammoIncendiary.ToString();
        ammoExplText.text = ammoExplosive.ToString();

        cost_ammoCritText.text = skillCost.CostOfammoCritical(ammoCriticalHit).ToString();
        cost_ammoIncText.text = skillCost.CostOfammoInc(ammoIncendiary).ToString();
        cost_ammoExplText.text = skillCost.CostOfammoExpl(ammoExplosive).ToString();
    }

    public int CalculateDamageOutput()
    {
        int player = playerDamage * playerFireRate * playerMultishot;
        int fixedPlyer = player + (ammoCriticalHit * 5 / 100) * player + ammoExplosive * 3 + ammoIncendiary * 3;
        int marine = baseDamage * baseFireRate * baseSquadSize;
        int baseAddon = (5 + baseDrones) * 2 + baseWires * 100 + baseAirStrike * 50 + baseNapalm * 50;

        int allDamage = player + fixedPlyer + marine + baseAddon;
        //Debug.Log("Damage Output: " + allDamage);
        return allDamage;
    }


    //GET value of x STAT
    public int GetplayerFireRate()
    {
        return playerFireRate;
    }
    public int GetplayerDamage()
    {
        return playerDamage;
    }
    public int GetplayerMultishot()
    {
        return playerMultishot;
    }
    public int GetplayerRecoilReduction()
    {
        return playerRecoilReduction;
    }
    public int GetbaseDamage()
    {
        return baseDamage;
    }
    public int GetbaseFireRate()
    {
        return baseFireRate;
    }
    public int GetbaseSquadSize()
    {
        return baseSquadSize;
    }
    public int GetbaseAirStrike()
    {
        return baseAirStrike;
    }
    public int GetbaseNapalm()
    {
        return baseNapalm;
    }
    public int GetbaseDrones()
    {
        return baseDrones;
    }
    public int GetbaseWires()
    {
        return baseWires;
    }
    public int GetammoIncendiary()
    {
        return ammoIncendiary;
    }
    public int GetammoExplosive()
    {
        return ammoExplosive;
    }
    public int GetammoCritical()
    {
        return ammoCriticalHit;
    }

    //INCREASE a SKILL
    public void increaseplayerFireRate()
    {
        if (exp >= skillCost.CostOfplayerFireRate(playerFireRate))
        {
            exp -= skillCost.CostOfplayerFireRate(playerFireRate);
            playerFireRate++;
            FindObjectOfType<Tower>().SetTowerFireRate();
            SetAllSkillText();
            if (playerFireRate == 20) cost_playerFireRateText.text = "MAX";
        }
    }

    public void increaseplayerDamage()
    {
        if (exp >= skillCost.CostOfplayerDamage(playerDamage))
        {
            exp -= skillCost.CostOfplayerDamage(playerDamage);
            playerDamage++;
            SetAllSkillText();
        }
    }

    public void increaseplayerMultishot()
    {
        if (exp >= skillCost.CostOfplayerMultishot(playerMultishot) && playerMultishot < 6)
        {
            exp -= skillCost.CostOfplayerMultishot(playerMultishot);
            playerMultishot++;
            FindObjectOfType<Tower>().SetMultishot();
            SetAllSkillText();
            if (playerMultishot == 6) cost_playerMultishotText.text = "MAX";
        }
    }

    public void increaseplayerRecoilReduction()
    {
        if (exp >= skillCost.CostOfplayerRecoilReduction(playerRecoilReduction) && playerRecoilReduction < 6)
        {
            exp -= skillCost.CostOfplayerRecoilReduction(playerRecoilReduction);
            playerRecoilReduction++;
            FindObjectOfType<Tower>().SetTowerRecoilReduction();
            SetAllSkillText();
            if (playerRecoilReduction == 6) cost_playerRecoilReductionText.text = "MAX";
        }
    }

    public void increasebaseSquadSize()
    {
        if (exp >= skillCost.CostOfbaseSquadSize(baseSquadSize) && baseSquadSize < 5)
        {
            exp -= skillCost.CostOfbaseSquadSize(baseSquadSize);
            baseSquadSize++;
            SetAllSkillText();
            FindObjectOfType<MarineSpawner>().SpawningMarine();
            if (baseSquadSize == 5) cost_baseSquadText.text = "MAX";
        }
    }

    public void increasebaseFireRate()
    {
        if (exp >= skillCost.CostOfbaseFireRate(baseFireRate))
        {
            exp -= skillCost.CostOfbaseFireRate(baseFireRate);
            baseFireRate++;
            SetAllSkillText();
            if (FindObjectsOfType<MarineTargeting>() != null)
            {
                MarineTargeting[] marines = FindObjectsOfType<MarineTargeting>();
                foreach (MarineTargeting marine in marines)
                {
                    marine.SetMarineParameters();
                }
            }
        }
    }

    public void increasebaseDamage()
    {
        if (exp >= skillCost.CostOfbaseDamage(baseDamage))
        {
            exp -= skillCost.CostOfbaseDamage(baseDamage);
            baseDamage++;
            SetAllSkillText();
        }
        if (FindObjectsOfType<MarineTargeting>() != null)
        {
            MarineTargeting[] marines = FindObjectsOfType<MarineTargeting>();
            foreach (MarineTargeting marine in marines)
            {
                marine.SetMarineParameters();
            }
        }
    }

    public void increasebaseWires()
    {
        if (exp >= skillCost.CostOfbaseWires(baseWires) && baseWires < 5)
        {
            exp -= skillCost.CostOfbaseWires(baseWires);
            baseWires++;
            SetAllSkillText();
            FindObjectOfType<WireSpawner>().SpawningWires(baseWires);
            if (baseWires == 5) cost_baseWiresText.text = "MAX";
        }
    }

    public void increaseDrones()
    {
        if (exp >= skillCost.CostOfbaseDrones(baseDrones))
        {
            exp -= skillCost.CostOfbaseDrones(baseDrones);
            baseDrones++;
            var drones = FindObjectsOfType<DroneMovement>();
            foreach (DroneMovement drone in drones)
            {
                drone.areDronesActive = true;
            }
            SetAllSkillText();
        }
    }

    public void increasebaseAirStrike()
    {
        if (exp >= skillCost.CostOfbaseAirStrike(baseAirStrike) && baseAirStrike == 0)
        {
            exp -= skillCost.CostOfbaseAirStrike(baseAirStrike);
            baseAirStrike++;
            SetAllSkillText();
            FindObjectOfType<AirStrike>().airStrikeValue = baseAirStrike;
            if (baseAirStrike == 1) cost_baseAirStrikeText.text = "MAX";
        }
    }

    public void increasebaseNapalm()
    {
        if (exp >= skillCost.CostOfbaseNapalm(baseNapalm) && baseNapalm == 0)
        {
            exp -= skillCost.CostOfbaseNapalm(baseNapalm);
            baseNapalm++;
            SetAllSkillText();
            FindObjectOfType<AirStrike>().napalmValue = baseNapalm;
            if (baseNapalm == 1) cost_baseNapalmText.text = "MAX";
        }
    }

    public void increaseammoCrit()
    {
        if (exp >= skillCost.CostOfammoCritical(ammoCriticalHit) && ammoCriticalHit < 20)
        {
            exp -= skillCost.CostOfammoCritical(ammoCriticalHit);
            ammoCriticalHit++;
            SetAllSkillText();
            if (ammoCriticalHit == 20) cost_ammoCritText.text = "MAX";
        }
    }

    public void increaseammoInc()
    {
        if (exp >= skillCost.CostOfammoInc(ammoIncendiary))
        {
            exp -= skillCost.CostOfammoInc(ammoIncendiary);
            ammoIncendiary++;
            SetAllSkillText();
        }
    }

    public void increaseammoExpl()
    {
        if (exp >= skillCost.CostOfammoExpl(ammoExplosive))
        {
            exp -= skillCost.CostOfammoExpl(ammoExplosive);
            ammoExplosive++;
            SetAllSkillText();
        }
    }



    // EXP and BODY COUNT manipulations

    public int IncreasePlayerExpierience(int earnedExp)
    {
        exp += earnedExp;
        return exp;
    }

    public int GetPlayerExp()
    {
        return exp;
    }

    

} // end of class
