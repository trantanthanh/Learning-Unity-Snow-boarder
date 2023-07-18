using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2d;
    [SerializeField] float torqueValueAmout = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rg2d.AddTorque(torqueValueAmout * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rg2d.AddTorque(-torqueValueAmout * Time.deltaTime);
        }
    }
}
