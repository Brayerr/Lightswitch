using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool InUse { get; set; }
    public abstract void Interact();
    public abstract void Release();
}
