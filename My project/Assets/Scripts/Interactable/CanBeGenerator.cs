using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanBeGenerator : Interactable
{
    float interactStart;
    float interactEnd;
    float counter; //debug
    public override void Interact()
    {
        if (!InUse)
        {
            interactStart = Time.time;
            InUse = true;

            Player.Instance.ChangeCounter(-1);
            Player.Instance.StartInteracting();
        }
        else
        {
            Debug.Log("Cooling Down");
        }
    }

    public override void Release()
    {
        Player.Instance.StopInteracting();
        interactEnd = Time.time;
    }

    private void Update()
    {
        if (InUse)
        {
            int i = 1;
            counter = Time.time;
            if (counter > interactStart + i)
            {
                Debug.Log(i);

                if (i == 10)
                {
                    Debug.Log("Generator Online");
                }
            }
        }
    }
}
