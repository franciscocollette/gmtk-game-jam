using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWhiteOnHit : MonoBehaviour, IOnDmg
{
    [SerializeField] private float duration = 0.15f;
    [SerializeField] private string whiteProp = "_Flash";

    [SerializeField] private List<Renderer> exceptions;

    private readonly List<Renderer> renderers = new();

    private float end;

    private void Awake()
    {
        end = Time.time;
        GetComponentsInChildren(renderers);
        foreach (var item in exceptions)
            renderers.Remove(item);
    }

    public void OnDmg(float amount)
    {
        end = Time.time + duration;
    }

    private void Update()
    {
        int on = Time.time <= end ? 1 : 0;
        foreach (var renderer in renderers)
        {
            renderer.material.SetInt(whiteProp, on);
        }
    }
}
