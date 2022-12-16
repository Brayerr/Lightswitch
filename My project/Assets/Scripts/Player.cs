using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    [SerializeField]
    List<Interactable> interactables = new List<Interactable>();
    [SerializeField]
    Interactable nearbyObject; //maybe track objects with a list?
    [SerializeField]
    int nearbyCounter = 0;
    bool isInteracting = false;

    public void StartInteracting()
    {
        isInteracting = true;
    }
    public void StopInteracting()
    {
        isInteracting = false;
    }

    public void ChangeCounter(int mod)
    {
        nearbyCounter += mod;
        interactables.Remove(nearbyObject);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (nearbyObject != null && !isInteracting)
            {
                nearbyObject.Interact();
            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (isInteracting)
            {
                nearbyObject.Release();
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        Interactable test = other.gameObject.GetComponent<Interactable>();
        if (test != null)
        {
            interactables.Add(test);
            nearbyCounter++;
            if (!isInteracting)
            {
                nearbyObject = test;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable test = other.gameObject.GetComponent<Interactable>();
        if (test != null)
        {
            interactables.Remove(test);
            nearbyCounter--;
            if (!isInteracting && nearbyCounter < 1)
            {
                nearbyObject = null;
            }
            else nearbyObject = interactables[interactables.Count - 1];
        }

    }
}
