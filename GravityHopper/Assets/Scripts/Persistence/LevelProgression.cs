using UnityEngine;

public class LevelProgression : Singleton<LevelProgression>
{

    private static readonly string UNLOCKED_LEVEL_PLAYER_PREFS_KEY = "currentLevel";

    protected override LevelProgression Init()
    {
        return this;
    }

    public void UnlockLevel(int level)
    {
        var currentUnlock = PlayerPrefs.GetInt(UNLOCKED_LEVEL_PLAYER_PREFS_KEY, 1);

        if (level > currentUnlock)
        {
            PlayerPrefs.SetInt(UNLOCKED_LEVEL_PLAYER_PREFS_KEY, level);
        }
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt(UNLOCKED_LEVEL_PLAYER_PREFS_KEY, 1);
    }
}
