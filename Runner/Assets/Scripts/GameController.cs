using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }
    public bool stopPlayer { get; private set; }
    private int terrainWidth;
    private int terrainLength;
    private int terrainPosX;
    private int terrainPosZ;
    private float timer;

    public Text scoreText;
    public Text timeLeftText;
    public Text gameOverText;

    public GameObject coin;
    public Terrain terrain;
    public int numberOfCoins;

    private void Start()
    {
        InitializeValues();
        UpdateScore();
        SpawnCoins();
    }

    private void Update()
    {
        if (!stopPlayer)
        {
            if (timer > 0.0f)
            {
                timer -= Time.deltaTime;
                timeLeftText.text = "Time left: " + timer.ToString("F");
            }
            else
            {
                timeLeftText.text = "You have no time";
                gameOverText.text = "Game Over!";
                stopPlayer = true;
            }
        }
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            int posX = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            int posZ = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            float posY = Terrain.activeTerrain.SampleHeight(new Vector3(posX, 0, posZ));
            Vector3 spawnPosition = new Vector3(posX, posY + 1, posZ);

            Instantiate(coin, spawnPosition, Quaternion.identity);
        }
    }

    private void InitializeValues()
    {
        score = 0;
        timer = 60;
        stopPlayer = false;
        scoreText.text = "";
        timeLeftText.text = "";
        gameOverText.text = "";

        terrainWidth = (int)terrain.terrainData.size.x - 10;
        terrainLength = (int)terrain.terrainData.size.z - 10;
        terrainPosX = (int)terrain.transform.position.x + 5;
        terrainPosZ = (int)terrain.transform.position.z + 5;
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    
    public void AddScore()
    {
        score += 10;
        UpdateScore();
    }

    public void Win()
    {
        gameOverText.text = "You Win!";
        timeLeftText.text = "";
        scoreText.text = "Total score: " + score;
        stopPlayer = true;
    }

}
