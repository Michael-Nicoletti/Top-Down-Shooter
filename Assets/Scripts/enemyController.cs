﻿using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {


    private float distanceFromEnemy;
    private Rigidbody2D rb;
    private objectPool oP;
    private float timeToFire;

    [SerializeField] GameObject player;
	[SerializeField] int moveSpeed = 5;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
        oP = GetComponent<objectPool>();

	}
	
	// Update is called once per frame
    void Update () {

        Vector3 pos = transform.position;
        Vector3 dir = player.transform.position - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        distanceFromEnemy = Vector3.Distance(transform.position, player.transform.position);
		
        if(distanceFromEnemy <= 4)
        {
            rb.velocity = Vector3.zero;

            if(timeToFire <= 0)
            {
                GameObject temp = oP.GetFromPool();

                temp.SetActive(true);
                Debug.DrawLine(transform.position, player.transform.position);
                temp.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                temp.transform.rotation = transform.rotation;
                temp.GetComponent<bulletScript>().fireBullet();
                timeToFire = 40;
            }
        }
        else if(distanceFromEnemy <= 7 && distanceFromEnemy >= 4)
        {
            if(rb.velocity.magnitude <= 2)
            {
                Vector2 force = transform.right * moveSpeed;
                rb.AddForce(force);
            }
        }
        else
            rb.velocity = Vector3.zero;

        timeToFire--;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Hit");

        if (col.tag == "bullet")
        {
            col.gameObject.SetActive(false);
            gameStats.addScore(10);
            Destroy(gameObject);
        }
    }
}
