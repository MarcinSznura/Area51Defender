using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCost : MonoBehaviour
{
    int playerFireRate;
    int playerDamage;
    int playerMultishot;
    int ammoCriticalHit;
    int ammoExplosive;
    int ammoIncendiary;
    int baseSquadSize;
    int baseFireRate;
    int baseDamage;
    int baseDrones;
    int baseWires;
    int baseAirStrike;
    int baseNapalm;

    public int CostOfplayerFireRate(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 0;

            case 2:
                return 5;

            case 3:
                return 10;

            case 4:
                return 15;

            case 5:
                return 20;

            case 6:
                return 25;

            case 7:
                return 30;

            case 8:
                return 50;

            case 9:
                return 70;

            case 10:
                return 90;

            case 11:
                return 110;

            case 12:
                return 130;

            case 13:
                return 150;

            case 14:
                return 170;

            case 15:
                return 200;

            case 16:
                return 250;

            case 17:
                return 300;

            case 18:
                return 400;

            case 19:
                return 500;

            case 20:
                return 600;

            default:
                return 9999;
        }
    }

    public int CostOfplayerDamage(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 0;

            case 2:
                return 10;

            case 3:
                return 20;

            case 4:
                return 40;

            case 5:
                return 80;

            case 6:
                return 150;

            case 7:
                return 300;

            case 8:
                return 400;

            case 9:
                return 500;

            case 10:
                return 600;

            case 11:
                return 700;

            case 12:
                return 800;

            case 13:
                return 900;

            case 14:
                return 1000;

            case 15:
                return 1100;

            case 16:
                return 1200;

            case 17:
                return 1300;

            case 18:
                return 1400;

            case 19:
                return 1500;

            case 20:
                return 1600;

            default:
                return 9999;
        }
    }

    public int CostOfplayerMultishot(int currLevel)
    {
        switch(currLevel+1)
        {
            case 1:
                return 0;

            case 2:
                return 200;

            case 3:
                return 800;

            case 4:
                return 2000;

            case 5:
                return 6000;

            default:
                return 9999;
        }
    }
    public int CostOfplayerRecoilReduction(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 400;

            case 2:
                return 800;

            case 3:
                return 1300;

            case 4:
                return 1500;

            case 5:
                return 2000;

            default:
                return 9999;
        }
    }
   

    public int CostOfbaseSquadSize(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 30;

            case 2:
                return 50;

            case 3:
                return 200;

            case 4:
                return 500;

            case 5:
                return 1000;
            default:
                return 9999;
        }
    }

    public int CostOfbaseFireRate(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 0;

            case 2:
                return 5;

            case 3:
                return 10;

            case 4:
                return 20;

            case 5:
                return 30;

            case 6:
                return 50;

            case 7:
                return 60;

            case 8:
                return 80;

            case 9:
                return 90;

            case 10:
                return 100;

            case 11:
                return 120;

            case 12:
                return 140;

            case 13:
                return 160;

            case 14:
                return 180;

            case 15:
                return 200;

            case 16:
                return 250;

            case 17:
                return 300;

            case 18:
                return 400;

            case 19:
                return 500;

            case 20:
                return 600;

            default:
                return 9999;
        }
    }

    public int CostOfbaseDamage(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 0;

            case 2:
                return 20;

            case 3:
                return 30;

            case 4:
                return 40;

            case 5:
                return 50;

            case 6:
                return 150;

            case 7:
                return 300;

            case 8:
                return 400;

            case 9:
                return 500;

            case 10:
                return 600;

            case 11:
                return 700;

            case 12:
                return 800;

            case 13:
                return 900;

            case 14:
                return 1000;

            case 15:
                return 1100;

            case 16:
                return 1200;

            case 17:
                return 1300;

            case 18:
                return 1400;

            case 19:
                return 1500;

            case 20:
                return 1600;

            default:
                return 9999;
        }
    }

    public int CostOfbaseDrones(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 0:
                return 400;

            case 1:
                return 300;

            case 2:
                return 400;

            case 3:
                return 500;

            case 4:
                return 600;

            case 5:
                return 800;

            case 6:
                return 1000;

            case 7:
                return 1200;

            case 8:
                return 1500;

            case 9:
                return 1900;

            case 10:
                return 2300;

            case 11:
                return 2800;

            case 12:
                return 3000;

            case 13:
                return 3300;

            case 14:
                return 4000;

            case 15:
                return 4500;

            case 16:
                return 5000;

            case 17:
                return 5500;

            case 18:
                return 7000;

            case 19:
                return 8500;

            case 20:
                return 9999;

            default:
                return 9999;
        }
    }

    public int CostOfbaseWires(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 200;

            case 2:
                return 400;

            case 3:
                return 800;

            case 4:
                return 2000;

            case 5:
                return 6000;

            default:
                return 9999;
        }
    }

    public int CostOfbaseAirStrike(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 500;

            default:
                return 9999;
        }
    }

    public int CostOfbaseNapalm(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 1:
                return 500;

            default:
                return 9999;
        }
    }


    public int CostOfammoExpl(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 0:
                return 100;

            case 1:
                return 200;

            case 2:
                return 300;

            case 3:
                return 400;

            case 4:
                return 600;

            case 5:
                return 800;

            case 6:
                return 1000;

            case 7:
                return 1200;

            case 8:
                return 1500;

            case 9:
                return 1900;

            case 10:
                return 2300;

            case 11:
                return 2800;

            case 12:
                return 3000;

            case 13:
                return 3300;

            case 14:
                return 4000;

            case 15:
                return 4500;

            case 16:
                return 5000;

            case 17:
                return 5500;

            case 18:
                return 7000;

            case 19:
                return 8500;

            case 20:
                return 9999;

            default:
                return 9999;
        }
    }

    public int CostOfammoCritical(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 0:
                return 50;

            case 1:
                return 100;

            case 2:
                return 200;

            case 3:
                return 400;

            case 4:
                return 600;

            case 5:
                return 800;

            case 6:
                return 1000;

            case 7:
                return 1200;

            case 8:
                return 1500;

            case 9:
                return 1900;

            case 10:
                return 2300;

            case 11:
                return 2800;

            case 12:
                return 3000;

            case 13:
                return 3300;

            case 14:
                return 4000;

            case 15:
                return 4500;

            case 16:
                return 5000;

            case 17:
                return 5500;

            case 18:
                return 7000;

            case 19:
                return 8500;

            case 20:
                return 9999;

            default:
                return 9999;
        }
    }

    public int CostOfammoInc(int currLevel)
    {
        switch (currLevel + 1)
        {
            case 0:
                return 200;

            case 1:
                return 300;

            case 2:
                return 600;

            case 3:
                return 1000;

            case 4:
                return 2000;

            case 5:
                return 3000;

            default:
                return 9999;
        }
    }
}
