using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comerciantewalkevent : MonoBehaviour
{
    public AK.Wwise.Event MyEvent;
   
    public void PlayFootstepSound()
    {
        MyEvent.Post(gameObject);
    }

}
