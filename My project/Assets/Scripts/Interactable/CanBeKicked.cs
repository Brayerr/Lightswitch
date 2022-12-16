using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeKicked : Interactable
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void Interact()
    {
        rb.AddExplosionForce(200, Player.Instance.transform.position, 300);
    }

    public override void Release()
    {

    }
}
