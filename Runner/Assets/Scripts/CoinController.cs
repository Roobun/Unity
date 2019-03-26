using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private void Start()
    {
        transform.Rotate(90, 0, 0);
    }

    private void Update()
    {
        transform.Rotate(0, 0, 2);
    }
}
