using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    Rigidbody2D myBody;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
         myBody.velocity = new Vector2(speed, myBody.velocity.y);
       // myBody.velocity = new Vector2(speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
