using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Schema;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;

    [SerializeField] GameObject shotPrefab;
    [SerializeField] float shotSpeed = 10f;
    [SerializeField] float rateOfFire = 0.1f;

    [SerializeField] GameObject player;

    Coroutine firingCoroutine;


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
        Fire();
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously() {
        while (true) {
            Vector3 shotPosition1 = new Vector3(player.transform.position.x - 0.5f, player.transform.position.y, 0);
            GameObject shot1 = Instantiate(shotPrefab, shotPosition1 /* transform.position*/, Quaternion.identity);
            shot1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shotSpeed);

            Vector3 shotPosition2 = new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, 0);
            GameObject shot2 = Instantiate(shotPrefab, shotPosition2, Quaternion.identity);
            shot2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, shotSpeed);

            yield return new WaitForSeconds(rateOfFire);
        }
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
