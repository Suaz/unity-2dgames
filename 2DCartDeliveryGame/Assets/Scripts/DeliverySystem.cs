using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    private Boolean hasPackage = false;
    [SerializeField] private float destroyDelay = .5f;
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("I just crushed");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Package":
                if (!hasPackage)
                {
                    Debug.Log("Package Picked");
                    hasPackage = true;
                    Destroy(col.gameObject, destroyDelay);
                    spriteRenderer.color = hasPackageColor;
                }
                break;
            case "Customer":
                if (hasPackage)
                {
                    Debug.Log("Package Delivered");
                    hasPackage = false;
                    spriteRenderer.color = noPackageColor;
                }

                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Debug.Log("staying...");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("im going home now");
    }
}