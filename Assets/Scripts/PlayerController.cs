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
    float gravityBackup = 1.0f;

    public bool canMove = true;
    SurfaceEffector2D surface2D;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        gravityBackup = rg2d.gravityScale;
        surface2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            checkRotatePlayer();
            RespondToBoost();
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            surface2D.speed = boostSpeed;
        }
        else if (FindObjectOfType<DustTrail>().IsOnAir && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            rg2d.gravityScale = gravityBackup * 5;
            // surface2D.speed = lowSpeed;
        }
        else
        {
            rg2d.gravityScale = gravityBackup;
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
