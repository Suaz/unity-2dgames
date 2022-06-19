using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CartController : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 300;

    [SerializeField]  private float moveSpeed = 0;
    [SerializeField] private float initialSpeed = 20;
    [SerializeField] private float boostSpeed = 30;
    [SerializeField] private float bumpSpeed = 12;

    private float modifierTime = 0;

    private void Start()
    {
        moveSpeed = initialSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Booster":
                modifierTime = 5;
                moveSpeed = boostSpeed;
                break;
            case "Bumper":
                modifierTime = 5;
                moveSpeed = bumpSpeed;
                break;
        }
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);

        if (moveAmount != 0)
        {
            float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime * moveAmount;
            transform.Rotate(0, 0, -steerAmount);
        }

        if (modifierTime > 0)
        {
            modifierTime -= Time.deltaTime;
        }
        else
        {
            moveSpeed = initialSpeed;
        }
    }
}