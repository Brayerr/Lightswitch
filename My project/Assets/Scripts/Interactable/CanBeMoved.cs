using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeMoved : Interactable
{
    Transform originalParent;
    private void Start()
    {
        originalParent = this.transform.parent;
    }
    public override void Interact()
    {
        transform.SetParent(Player.Instance.transform);
        Player.Instance.ChangeCounter(-1);
        Player.Instance.StartInteracting();
    }

    public override void Release()
    {
        transform.SetParent(originalParent);
        Player.Instance.StopInteracting();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Interact();
            
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Player.Instance().SetNearbyObject(null);

    //}

}
