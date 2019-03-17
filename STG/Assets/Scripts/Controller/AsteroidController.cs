using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float            speed;

    private Game            game;
    private LevelController levelController;
    private Rigidbody       rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameController gameController = gameControllerObject.GetComponent<GameController>();

        game = gameController.game;
        levelController = gameController.levelController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Asteroid"))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            game.HitByEnemy();

            if (game.m_gameOver)
            {
                levelController.Death();
            }
        }

        if (other.CompareTag("Bolt"))
        {
            game.AddScore();
            levelController.level.SubScoreLeft();
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
