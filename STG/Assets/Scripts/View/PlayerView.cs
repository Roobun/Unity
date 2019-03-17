using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerView : MonoBehaviour
{
    public PlayerController playerController { private set; get; }
    public Transform[]      shotsSpawn;
    public Boundary         boundary;
    public float            speed;
    public float            fireRate;

    private Player          player;
    private Rigidbody       rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = new Player(rb.position, speed);
        playerController = new PlayerController(fireRate, shotsSpawn);
    }

    private void Update()
    {
        playerController.Fire();
    }

    private void FixedUpdate()
    {
        Vector3 movement = playerController.GetMovement();
        player.Move(rb, movement, boundary);
    }
}
