using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteFlicker : MonoBehaviour
{
    public Sprite canUpgrade;
    public Sprite cantUpgrade;
    public Button but;
    [SerializeField] int buttonIndex;

    int playerExp;
    int cost;
    SkillCost skillCost;
    Upgrademenu upMenu;

    private void Start()
    {
       upMenu = FindObjectOfType<Upgrademenu>();
       skillCost = FindObjectOfType<SkillCost>();
    }

    private void Update()
    {
        ChangeImage();
    }

    private void GetCost()
    {
        switch (buttonIndex)
        {
            case 1:
                cost = skillCost.CostOfplayerFireRate(upMenu.GetplayerFireRate());
                break;

            case 2:
                cost = skillCost.CostOfplayerDamage(upMenu.GetplayerDamage());
                break;

            case 3:
                cost = skillCost.CostOfplayerMultishot(upMenu.GetplayerMultishot());
                break;

            case 4:
                cost = skillCost.CostOfplayerRecoilReduction(upMenu.GetplayerRecoilReduction());
                break;

            case 5:
                cost = skillCost.CostOfbaseSquadSize(upMenu.GetbaseSquadSize());
                break;

            case 6:
                cost = skillCost.CostOfbaseFireRate(upMenu.GetbaseFireRate());
                break;

            case 7:
                cost = skillCost.CostOfbaseDamage(upMenu.GetbaseDamage());
                break;

            case 8:
                cost = skillCost.CostOfbaseDrones(upMenu.GetbaseDrones());
                break;

            case 9:
                cost = skillCost.CostOfbaseWires(upMenu.GetbaseWires());
                break;

            case 10:
                cost = skillCost.CostOfbaseAirStrike(upMenu.GetbaseAirStrike());
                break;

            case 11:
                cost = skillCost.CostOfbaseNapalm(upMenu.GetbaseNapalm());
                break;

            case 12:
                cost = skillCost.CostOfammoCritical(upMenu.GetammoCritical());
                break;

            case 13:
                cost = skillCost.CostOfammoExpl(upMenu.GetammoExplosive());
                break;

            case 14:
                cost = skillCost.CostOfammoInc(upMenu.GetammoIncendiary());
                break;
        }
    }

    public void ChangeImage()
    {
        switch (buttonIndex)
        {
            case 1:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 2:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 3:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 4:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 5:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 6:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 7:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 8:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 9:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 10:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 11:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 12:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 13:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;

            case 14:
                GetCost();
                if (cost <= upMenu.GetPlayerExp())
                    but.image.sprite = canUpgrade;
                else
                {
                    but.image.sprite = cantUpgrade;
                }
                break;
        }
       
    }
}
