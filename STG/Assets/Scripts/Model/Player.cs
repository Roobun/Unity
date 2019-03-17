using UnityEngine;

public class Player
{
    public Vector3  m_position { set; get; }
    public float    m_speed { private set; get; }

    public Player(Vector3 position, float speed)
    {
        m_position = position;
        m_speed = speed;
    }

    public void Move(Rigidbody rb, Vector3 movement, Boundary boundary)
    {
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        m_position = rb.position;
        rb.velocity = movement * m_speed;
    }
}

