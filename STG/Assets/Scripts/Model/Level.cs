using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public int  m_level { private set; get; }
    public int  m_scoreLeft { set; get; }
    public int  m_scoreToLvlUp { private set; get; }
    public int  m_asteroids { private set; get; }
    public bool m_goingToNextLevel { set; get; }

    public Level()
    {
        Restart();
    }

    public void Restart()
    {
        m_level = 0;
        m_scoreToLvlUp = 500;
        m_scoreLeft = m_scoreToLvlUp;
        m_asteroids = 10;
        m_goingToNextLevel = false;
    }

    public void LvlUp()
    {
        m_level++;

        int random = Random.Range(1, m_level);
        m_scoreToLvlUp += random * 200;
        m_scoreLeft = m_scoreToLvlUp;
        m_asteroids += random * 4;

        m_goingToNextLevel = true;
    }

    public void SubScoreLeft()
    {
        m_scoreLeft -= 20;
        
        if (m_scoreLeft < 1)
        {
            m_scoreLeft = 0;
            
            LvlUp();
        }
    }

    public void LoadLevel(int level, int scoreToLvlUp, int asteroids)
    {
        m_level = level;
        m_scoreToLvlUp = scoreToLvlUp;
        m_scoreLeft = scoreToLvlUp;
        m_asteroids = asteroids;
    }
}
