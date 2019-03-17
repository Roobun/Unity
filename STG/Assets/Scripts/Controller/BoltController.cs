using UnityEngine;

public class BoltController : MonoBehaviour
{
    public float      speed;
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
