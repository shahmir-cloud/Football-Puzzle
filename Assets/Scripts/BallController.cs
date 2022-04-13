using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
    private float trunSpeed = 24.0f;
    private float horizontalInput;
    private Rigidbody ballRb;
    private float forwardForce = 30f;
    public float upForce = 23f;
    private bool dead = false;
    private bool inspace = false;
    
    UIManager UI;

    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * trunSpeed * horizontalInput);
        if(Input.GetKeyDown(KeyCode.Space) && dead==false)
        {
            ballRb.AddForce(Vector3.up * UI.slide.value, ForceMode.Impulse);
            ballRb.AddRelativeForce(Vector3.forward * forwardForce, ForceMode.Impulse);
            inspace = true;
           // Debug.Log(UI.slide.value);
        }

        if(transform.position.z > 60)
        {
            dead = true;
            UI.activate = true;
        }
        distroyBall();

    }

    private void distroyBall()
    {
        if (transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground") && inspace)
        {
            Destroy(gameObject);
        }
    }
}
