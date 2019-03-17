using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text     score;
    public Text     scoreLeft;
    public Text     lives;
    public Text     gameOver;
    public Text     levelNumber;

    private Game    game;
    private Level   level;

    private void Start()
    {
        GameController gameController = GetComponent<GameController>();

        game = gameController.game;
        level = gameController.levelController.level;
    }

    private void Update()
    {
        score.text = "Score: " + game.m_score;
        scoreLeft.text = "Score left: " + level.m_scoreLeft;
        levelNumber.text = "Level: " + level.m_level;

        if (!game.m_gameOver)
        {
            lives.text = "Lives: " + game.m_lives;
            gameOver.text = "";
        }
        else
        {
            lives.text = "Press 'R' for Restart";
            gameOver.text = "Game Over!";
        }

        if (level.m_goingToNextLevel)
        {
            gameOver.text = "Next Level!";
        }
    }
}
