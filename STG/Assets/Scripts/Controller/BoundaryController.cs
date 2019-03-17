using UnityEngine;

public class BoundaryController : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
