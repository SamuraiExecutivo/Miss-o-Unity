using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour {

    public bool isFood;
    private GameObject aux;
    public Rigidbody rb;


    void Start() {
        aux = GameObject.Find("GameController");
        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        if (rb.transform.position.x > 15 || rb.transform.position.x < -15 || rb.transform.position.y > 9 || rb.transform.position.y < -9) {
            aux.GetComponent<GameController>().AddScore(-10);
            Destroy(this.gameObject);
        }
        
    }

    void OnCollisionEnter(Collision ress) {
        if (isFood && ress.gameObject.tag == "fcontainer") {
            aux.GetComponent<GameController>().AddScore(10);
            Destroy(this.gameObject);
        } else if (!isFood && ress.gameObject.tag == "wcontainer") {
            aux.GetComponent<GameController>().AddScore(10);
            Destroy(this.gameObject);            
        }  else if (ress.gameObject.tag == "wcontainer" || ress.gameObject.tag == "fcontainer") {
            aux.GetComponent<GameController>().AddScore(-15);
            Destroy(this.gameObject);
        }
        
    }
}
