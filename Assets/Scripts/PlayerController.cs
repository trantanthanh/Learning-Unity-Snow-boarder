using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2d;
    [SerializeField] float torqueValueAmout = 60.0f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float normalSpeed = 15f;
    [SerializeField] float lowSpeed = 10f;
    SurfaceEffector2D surface2D;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        surface2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        checkRotatePlayer();
        RespondToBoost();
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            surface2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            surface2D.speed = lowSpeed;
        }
        else
        {
            surface2D.speed = normalSpeed;
        }
    }

    private void checkRotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rg2d.AddTorque(torqueValueAmout * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rg2d.AddTorque(-torqueValueAmout * Time.deltaTime);
        }
    }
}
