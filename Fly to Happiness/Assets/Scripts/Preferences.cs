using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Preferences 
{
    public static string easy = "easy";
    public static string medium = "medium";
    public static string hard = "hard";

    public static string easyScore = "easyScore";
    public static string mediumScore = "mediumScore";
    public static string hardScore = "hardScore";

    public static string easyStar = "easyStar";
    public static string mediumStar = "mediumStar";
    public static string hardStar = "hardStar";

    public static string musicOn = "musicOn";

    public static void EasyValue(int easy)
    {
        PlayerPrefs.SetInt(Preferences.easy, easy);
    }

    public static int EasyValueRead()
    {
        return PlayerPrefs.GetInt(Preferences.easy);
    }

    public static void MediumValue(int medium)
    {
        PlayerPrefs.SetInt(Preferences.medium, medium);
    }

    public static int MediumValueRead()
    {
        return PlayerPrefs.GetInt(Preferences.medium);
    }

    public static void HardValue(int hard)
    {
        PlayerPrefs.SetInt(Preferences.hard, hard);
    }

    public static int HardValueRead()
    {
        return PlayerPrefs.GetInt(Preferences.hard);
    }




    public static void EasyValueScore(int easyScore)
    {
        PlayerPrefs.SetInt(Preferences.easyScore, easyScore);
    }

    public static int EasyValueScoreRead()
    {
        return PlayerPrefs.GetInt(Preferences.easyScore);
    }

    public static void MediumValueScore(int mediumScore)
    {
        PlayerPrefs.SetInt(Preferences.mediumScore, mediumScore);
    }

    public static int MediumValueScoreRead()
    {
        return PlayerPrefs.GetInt(Preferences.mediumScore);
    }

    public static void HardValueScore(int hardScore)
    {
        PlayerPrefs.SetInt(Preferences.hardScore, hardScore);
    }

    public static int HardValueScoreRead()
    {
        return PlayerPrefs.GetInt(Preferences.hardScore);
    }





    public static void EasyValueStar(int easyStar)
    {
        PlayerPrefs.SetInt(Preferences.easyStar, easyStar);
    }

    public static int EasyValueStarRead()
    {
        return PlayerPrefs.GetInt(Preferences.easyStar);
    }

    public static void MediumValueStar(int mediumStar)
    {
        PlayerPrefs.SetInt(Preferences.mediumStar, mediumStar);
    }

    public static int MediumValueStarRead()
    {
        return PlayerPrefs.GetInt(Preferences.mediumStar);
    }

    public static void HardValueStar(int hardStar)
    {
        PlayerPrefs.SetInt(Preferences.hardStar, hardStar);
    }

    public static int HardValueStarRead()
    {
        return PlayerPrefs.GetInt(Preferences.hardStar);
    }


    public static void MusicOnValue(int musicOn)
    {
        PlayerPrefs.SetInt(Preferences.musicOn, musicOn);
    }

    public static int MusicOnValueRead()
    {
        return PlayerPrefs.GetInt(Preferences.musicOn);
    }



    public static bool Register()
    {
        if(PlayerPrefs.HasKey(Preferences.easy) || PlayerPrefs.HasKey(Preferences.medium) || PlayerPrefs.HasKey(Preferences.hard))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool MusicRegister()
    {
        if (PlayerPrefs.HasKey(Preferences.musicOn))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
