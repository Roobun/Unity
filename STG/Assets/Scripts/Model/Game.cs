using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public int  m_score { private set; get; }
    public int  m_lives { private set; get; }
    public bool m_gameOver { private set; get; }

    public Game(int livesAtStart)
    {
        Restart(livesAtStart);
    }

    public void LoadGame(int score, int lives)
    {
        m_score = score;
        m_lives = lives;
    }

    public void Restart(int livesAtStart)
    {
        m_score = 0;
        m_lives = livesAtStart;
        m_gameOver = false;
    }

    public void AddScore()
    {
        m_score += 20;
    }

    public void HitByEnemy()
    {
        m_lives--;
        if (m_lives < 1)
        {
            m_gameOver = true;
        }
    }
}
