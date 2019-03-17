using UnityEngine;

public class GameController : MonoBehaviour
{
    public LevelController      levelController { private set; get; }
    public int                  livesAtStart;
    public Game                 game;

    private SaveGameController  saveController;
    private bool                needToSave;

    private void Start()
    {
        game = new Game(livesAtStart);
        GameObject levelControllerObejct = GameObject.FindWithTag("LevelController");
        levelController = levelControllerObejct.GetComponent<LevelController>();

        saveController = new SaveGameController();
        RestoreGame();
        needToSave = true;
    }

    private void Update()
    {
        if (levelController.level.m_goingToNextLevel)
        {
            if (needToSave)
            {
                SaveGame();
                needToSave = false;
            }
        }
        else
        {
            needToSave = true;
        }
    }

    private void FixedUpdate()
    {
        if (game.m_gameOver && Input.GetKeyDown(KeyCode.R))
        {
            game.Restart(livesAtStart);
            levelController.Restart();
            SaveGame();
        }
    }

    private void SaveGame()
    {
        saveController.SaveGame(game.m_lives, game.m_score, levelController.level.m_scoreToLvlUp, 
            levelController.level.m_level, levelController.level.m_asteroids);
    }

    private void RestoreGame()
    {
        SaveGame save = saveController.RestoreGame();
        if (save != null)
        {
            game.LoadGame(save.m_score, save.m_lives);
            levelController.level.LoadLevel(save.m_level, save.m_scoreToLvlUp, save.m_asteroids);
        }
    }
}
