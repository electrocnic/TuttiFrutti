using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burb : MonoBehaviour {

    private Vector2 _startPosition;
    
    // Start is called before the first frame update
    void Start() {
        _startPosition = GetComponent<Rigidbody2D>().position;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseDown() {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    void OnMouseUp() {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction * 1000);
        
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void OnMouseDrag() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Transform>().position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update() { }
}