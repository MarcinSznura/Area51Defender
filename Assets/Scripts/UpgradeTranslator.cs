using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTranslator : MonoBehaviour
{
    [Header("Labels")]
    [SerializeField] TextMeshProUGUI pLabelT;
    [SerializeField] TextMeshProUGUI bLabelT;
    [SerializeField] TextMeshProUGUI aLabelT;

    [Header("Skills name")]
    [SerializeField] TextMeshProUGUI PSkill1T;
    [SerializeField] TextMeshProUGUI PSkill2T;
    [SerializeField] TextMeshProUGUI PSkill3T;
    [SerializeField] TextMeshProUGUI PSkill4T;

    [SerializeField] TextMeshProUGUI BSkill1T;
    [SerializeField] TextMeshProUGUI BSkill2T;
    [SerializeField] TextMeshProUGUI BSkill3T;
    [SerializeField] TextMeshProUGUI BSkill4T;
    [SerializeField] TextMeshProUGUI BSkill5T;

    [SerializeField] TextMeshProUGUI ASkill1T;
    [SerializeField] TextMeshProUGUI ASkill2T;
    [SerializeField] TextMeshProUGUI ASkill3T;
    [SerializeField] TextMeshProUGUI ASkill4T;
    [SerializeField] TextMeshProUGUI ASkill5T;

    [Header("Skills hints")]
    [SerializeField] TextMeshProUGUI PShint1T;
    [SerializeField] TextMeshProUGUI PShint2T;
    [SerializeField] TextMeshProUGUI PShint3T;
    [SerializeField] TextMeshProUGUI PShint4T;

    [SerializeField] TextMeshProUGUI BShint1T;
    [SerializeField] TextMeshProUGUI BShint2T;
    [SerializeField] TextMeshProUGUI BShint3T;
    [SerializeField] TextMeshProUGUI BShint4T;
    [SerializeField] TextMeshProUGUI BShint5T;

    [SerializeField] TextMeshProUGUI AShint1T;
    [SerializeField] TextMeshProUGUI AShint2T;
    [SerializeField] TextMeshProUGUI AShint3T;
    [SerializeField] TextMeshProUGUI AShint4T;
    [SerializeField] TextMeshProUGUI AShint5T;


    
    public void SetSkillLanguage(int lang)
    {
        if (lang == 0)
        {
            string PLabel = "TURRET UPGRADES";
            string BLabel = "BASE UPGRADES";
            string ALabel = "AMMO/SKILLS UPGRADES";

            string PSkill1 = "ROUND PER SECOND";
            string PSkill2 = "PENETRATION";
            string PSkill3 = "ACTIVE \nBARELL";
            string PSkill4 = "RECOIL \nREDUCTION";

            string BSkill1 = "SQUAD SIZE";
            string BSkill2 = "FIRE RATE";
            string BSkill3 = "SERIES";
            string BSkill4 = "DRONES";
            string BSkill5 = "WIRES";

            string ASkill1 = "CRITICAL \nHIT";
            string ASkill2 = "EXPLOSIVE \nAMMO";
            string ASkill3 = "INCENDIARY AMMO";
            string ASkill4 = "AIR STRIKE";
            string ASkill5 = "NAPALM";

            string PSHint1 = "NUMBER OF FULL BARREL SPINS PER SECOND";
            string PSHint2 = "BETTER PENETRATION = MORE DAMAGE TO ENEMY";
            string PSHint3 = "ACTIVATE ANOTHER BARREL ON YOUR TURRET \nMORE FIRE POWER = MORE RECOIL";
            string PSHint4 = "REDUCE RECOIL OF YOUR TURRET";

            string BSHint1 = "NUMBER OF SOLDIES DEFENDING AREA 51";
            string BSHint2 = "DECREASE TIME BETWEEN SERIES";
            string BSHint3 = "NUMBER OF SHOOTS IN SINGLE SERIES";
            string BSHint4 = "DRONES DAMAGE AND MAGAZINE SIZE";
            string BSHint5 = "NUMBER OF WIRES THAT WILL SLOW DOWN INCOMING RAIDERS";

            string ASHint1 = "CHANCE TO DOUBLE YOUR DAMAGE";
            string ASHint2 = "EXPLOSIVE BULLETS ADDING AREA DAMAGE \n HIGER LVL HIGER DAMAGE";
            string ASHint3 = "FIRE BULLETS SETTING ENEMIES ON FIRE \nBURNING ENEMIES RECEIVING DMG OVER TIME";
            string ASHint4 = "DEAL DAMAGE TO ALL RAIDERS";
            string ASHint5 = "SET ALL RAIDERS ON FIRE";

            pLabelT.text = PLabel;
            bLabelT.text = BLabel;
            aLabelT.text = ALabel;

            PSkill1T.text = PSkill1;
            PSkill2T.text = PSkill2;
            PSkill3T.text = PSkill3;
            PSkill4T.text = PSkill4;
            BSkill1T.text = BSkill1;
            BSkill2T.text = BSkill2;
            BSkill3T.text = BSkill3;
            BSkill4T.text = BSkill4;
            BSkill5T.text = BSkill5;
            ASkill1T.text = ASkill1;
            ASkill2T.text = ASkill2;
            ASkill3T.text = ASkill3;
            ASkill4T.text = ASkill4;
            ASkill5T.text = ASkill5;

            PShint1T.text = PSHint1;
            PShint2T.text = PSHint2;
            PShint3T.text = PSHint3;
            PShint4T.text = PSHint4;
            BShint1T.text = BSHint1;
            BShint2T.text = BSHint2;
            BShint3T.text = BSHint3;
            BShint4T.text = BSHint4;
            BShint5T.text = BSHint5;
            AShint1T.text = ASHint1;
            AShint2T.text = ASHint2;
            AShint3T.text = ASHint3;
            AShint4T.text = ASHint4;
            AShint5T.text = ASHint5;
        }
        else
        {
            string PLabel = "ULEPSZENIA DZIALKA";
            string BLabel = "ULEPSZENIA BAZY";
            string ALabel = "ULEPSZENIA AUMUNICJI";

            string PSkill1 = "STRZALY NA SEKUNDE";
            string PSkill2 = "PENETRACJA";
            string PSkill3 = "AKTYWNE \nLUFY";
            string PSkill4 = "ZMNIEJSZENIE \nODRZUTU";

            string BSkill1 = "ROZMIAR ODDZIALU";
            string BSkill2 = "PREDKOSC STRZELANIA";
            string BSkill3 = "STRZALY W SERII";
            string BSkill4 = "DRONY";
            string BSkill5 = "ZASIEKI";

            string ASkill1 = "TRAFIENIA \nKRYTYCZNE";
            string ASkill2 = "AMMUNICJA \nWYBUCHOWA";
            string ASkill3 = "AMUNICJA PODPALAJACA";
            string ASkill4 = "NALOT";
            string ASkill5 = "NAPALM";

            string PSHint1 = "LICZBA OBROTOW NA SEKUNDE";
            string PSHint2 = "LEPSZA PENETRACJA = WIECEJ OBRAZEN";
            string PSHint3 = "AKTYWUJ DODATKOWA LUFE DZIALKA \nWIECEJ WYSTRZALOW = WIEKSZY ODRZUT";
            string PSHint4 = "ZMNIEJSZA ODRZUT DZIALKA";

            string BSHint1 = "LICZBA ZOLNIERZY BRONIACYCH BAZY";
            string BSHint2 = "ZMNIEJSZA CZAS POMIEDZY SERIAMI";
            string BSHint3 = "LICZBA STRZALOW W SERII";
            string BSHint4 = "ZWIEKSZA OBRAZENIA I MAGAZYNKI DRONOW";
            string BSHint5 = "LICZBA ZASIEKOW SPOWALNIAJACYCH WROGOW";

            string ASHint1 = "SZANSA NA PODWOJENIE OBRAZEN";
            string ASHint2 = "OBRAZENIA OBSZAROWE \n WIEKSZY LVL = WIEKSZE OBRAZENIA";
            string ASHint3 = "PODPALENIE WROGOW \nPLONACY WROGOWIE OTRZYUJA OBRAZENIA ";
            string ASHint4 = "ZADAJE OBRAZENIA WSZYSTKIM WROGOM";
            string ASHint5 = "PODPALA WSZYSTKICH WROGOW";

            pLabelT.text = PLabel;
            bLabelT.text = BLabel;
            aLabelT.text = ALabel;

            PSkill1T.text = PSkill1;
            PSkill2T.text = PSkill2;
            PSkill3T.text = PSkill3;
            PSkill4T.text = PSkill4;
            BSkill1T.text = BSkill1;
            BSkill2T.text = BSkill2;
            BSkill3T.text = BSkill3;
            BSkill4T.text = BSkill4;
            BSkill5T.text = BSkill5;
            ASkill1T.text = ASkill1;
            ASkill2T.text = ASkill2;
            ASkill3T.text = ASkill3;
            ASkill4T.text = ASkill4;
            ASkill5T.text = ASkill5;

            PShint1T.text = PSHint1;
            PShint2T.text = PSHint2;
            PShint3T.text = PSHint3;
            PShint4T.text = PSHint4;
            BShint1T.text = BSHint1;
            BShint2T.text = BSHint2;
            BShint3T.text = BSHint3;
            BShint4T.text = BSHint4;
            BShint5T.text = BSHint5;
            AShint1T.text = ASHint1;
            AShint2T.text = ASHint2;
            AShint3T.text = ASHint3;
            AShint4T.text = ASHint4;
            AShint5T.text = ASHint5;
        }


}


}
