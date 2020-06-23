using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;


    float xMin;
    float xMax;

    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        SetMoveBoundaries();
    }

    

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SetMoveBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move() 
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(Mathf.Clamp(newXPos, xMin, xMax) , Mathf.Clamp(newYPos, yMin, yMax));
    }
}
