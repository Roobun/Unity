using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[]     asteroidTypes;
    public Vector3          spawnCoordinates;
    public Level            level;
    public float            spawnWait;
    public float            waveWait;
    public float            levelWait;

    private bool            waveEnd;
    private bool            gameOver;
    private PoolController  pool;

    public void Death()
    {
        gameOver = true;
    }

    public void Restart()
    {
        gameOver = false;
        level.Restart();
    }

    private void Start()
    {
        level = new Level();
        waveEnd = true;
        gameOver = false;

        pool = GetComponent<PoolController>();
    }

    private void Update()
    {
        if (waveEnd && !gameOver)
        {
            StartCoroutine(SpawnAsteroids());
        }
    }

    private IEnumerator SpawnAsteroids()
    {
        if (level.m_goingToNextLevel)
        {
            pool.NextObject();
        }

        waveEnd = false;
        level.m_goingToNextLevel = false;

        yield return new WaitForSeconds(waveWait);

        for (int i = 0; i < level.m_asteroids; i++)
        {
            if (level.m_goingToNextLevel)
            {
                yield return new WaitForSeconds(levelWait);
                break;
            }

            if (gameOver)
            {
                break;
            }

            yield return new WaitForSeconds(spawnWait);

            GameObject obj = pool.GetPooledObject();
            if (obj != null)
            {
                obj.transform.position = new Vector3(Random.Range(-spawnCoordinates.x, spawnCoordinates.x), spawnCoordinates.y, spawnCoordinates.z);
                obj.transform.rotation = Quaternion.identity;
                obj.SetActive(true);
            }
        }

        waveEnd = true;
    }
}
