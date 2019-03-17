using UnityEngine;

public class SaveGameController 
{
    public SaveGame RestoreGame()
    {
        string json = PlayerPrefs.GetString("SaveGame");
        if (json != null && json.Length > 0)
        {
            SaveGame save = JsonUtility.FromJson<SaveGame>(json);
            if (save != null)
            {
                return save;
            }
        }

        return null;
    }

    public void SaveGame(int lives, int score, int scoreToLvlUp, int level, int asteroids)
    {
        SaveGame save = new SaveGame
        {
            m_lives = lives,
            m_score = score,
            m_scoreToLvlUp = scoreToLvlUp,
            m_level = level,
            m_asteroids = asteroids
        };

        string json = JsonUtility.ToJson(save);
        PlayerPrefs.SetString("SaveGame", json);
    }
}
