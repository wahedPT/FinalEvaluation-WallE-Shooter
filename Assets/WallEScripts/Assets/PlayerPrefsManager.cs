using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_vol";
    const string DIFFICULT_KEY = "difficult";
    const string LEVEL_KEY = "level_difficult_unlocked";

   public static void SetMasterVolume(float volume)
    {
        if(volume>0f&&volume<1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);

        }
        else
        {
            Debug.LogError("volume out of Range");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if(level<=SceneManager.sceneCountInBuildSettings-1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("This level is not in bulit order");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool islevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings-1)
        {
            //return bool
            return islevelUnlocked;
        }
        else
        {
            Debug.LogError("This level is not in bulit order");
            return false;
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if(difficulty>=0f&&difficulty<=1f)
        {
            PlayerPrefs.SetFloat(DIFFICULT_KEY, difficulty);
        }
        else
        {
            Debug.LogError("This Difficulty level is not in out of range");
            
        }
    } 
   public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULT_KEY);
    }





//private void Start()
//    {
//        print(GetMasterVolume());
//       SetMasterVolume(0.3f);
//        print(GetMasterVolume());
//       print( IsLevelUnlocked(2));
//        UnlockLevel(2);
//        print(IsLevelUnlocked(2));
//        print(GetDifficulty());
//        SetDifficulty(0.5f);
//        print(GetDifficulty()); 

//    }

}
