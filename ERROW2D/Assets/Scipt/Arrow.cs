using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject arrow;


    public void Int(Vector2 velocity)
    {
        rb.AddForce(velocity, (ForceMode)ForceMode2D.Impulse);
    }

}
