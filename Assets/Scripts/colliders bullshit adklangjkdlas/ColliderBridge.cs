using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBridge : MonoBehaviour
{
    ColliderListener listener;
    public void Initialize(ColliderListener l)
    {
        listener = l;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        listener.OnCollisionEnter2D(collision);
    }
}
