using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
            float       rotationAxis;
            float       horizontalAxis;
            float       verticalAxis;
    public  float       rotSpeed;
    public  float       movSpeed;
    public  Rigidbody   rb;
    public GameObject   aux;

    void Start() {
        aux = GameObject.Find("GameController");
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if(!aux.GetComponent<GameController>().gameOver) SatelliteControl ();
    }

    void SatelliteControl () {

        if (rb.transform.position.y > -8 && rb.transform.position.y < 8) {
            verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime;
        } else {
            if (rb.transform.position.y > -8){
                verticalAxis = -0.001f;
            } else {
                verticalAxis = 0.001f;
            }
        }

        if (rb.transform.position.x > -13 && rb.transform.position.x < 13) {
            horizontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime;
        } else {
            if (rb.transform.position.x > -13) {
                horizontalAxis = -0.001f;
            } else {
                horizontalAxis = 0.001f;
            }
        }

        rotationAxis = Input.GetAxis("Rotation") * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, rotationAxis * rotSpeed) * Time.deltaTime);
        rb.velocity = new Vector3 (horizontalAxis * movSpeed, verticalAxis * movSpeed, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
