using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hittree : MonoBehaviour
{
    public AK.Wwise.Event MyEventtree;
    // Start is called before the first frame update
    public void playHitTree()
    {
        MyEventtree.Post(gameObject);
    }

}
