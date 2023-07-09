using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combattoharvest : MonoBehaviour
{
    public AK.Wwise.Event MyEvent;
    public GameObject go;

  
    private void OnEnable() {
        MyEvent.Post(go); 
    }
}
