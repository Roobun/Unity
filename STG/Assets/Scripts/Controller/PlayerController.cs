using UnityEngine;

public class PlayerController
{
    private PoolController pool;
    private Transform[]    shotsSpawn;
    private float          nextFire;
    private float          fireRate;

    public PlayerController(float fireRate, Transform[] shotsSpawn)
    {
        nextFire = 0.0f;
        this.fireRate = fireRate;
        this.shotsSpawn = shotsSpawn;

        GameObject playerObject = GameObject.FindWithTag("Player");
        pool =  playerObject.GetComponent<PoolController>();
    }

    public Vector3 GetMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        return new Vector3(moveHorizontal, 0.0f, moveVertical);
    }

    public void Fire()
    {
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            for (int i = 0; i < shotsSpawn.Length; i++)
            {
                GameObject obj = pool.GetPooledObject();
                if (obj != null)
                {
                    obj.transform.position = shotsSpawn[i].position;
                    obj.transform.rotation = shotsSpawn[i].rotation;
                    obj.SetActive(true);
                }
            }
        }
    }
}
