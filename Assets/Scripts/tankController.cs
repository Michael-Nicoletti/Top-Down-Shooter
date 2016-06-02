using UnityEngine;
using System.Collections;

public class tankController : MonoBehaviour {

    private GameObject[] targetList;
    private int i = 0;
    private GameObject currentTarget;
    private Rigidbody2D rb;
    private bool alreadyIterated = false;
    private int health;

    public GameObject cannon;
    public GameObject player;

    [SerializeField] int moveSpeed;

	// Use this for initialization
	void Start () {

        health = 5;

        rb = GetComponent<Rigidbody2D>();

        targetList = GameObject.FindGameObjectsWithTag("tankNode");

        currentTarget = targetList[0];
	
	}
	
	// Update is called once per frame
	void Update () {

        //Tank Movement
        currentTarget = targetList[i];

        float currentDistanceFromTarget = Vector3.Distance(transform.position, currentTarget.transform.position);

        if (currentDistanceFromTarget < 3)
        {
            if (i < targetList.Length - 1 && alreadyIterated == false)
            {
                rb.velocity = Vector3.zero;
                Debug.Log("This Happened");
                i++;
                alreadyIterated = true;
            }
            else
            {
                if (alreadyIterated == false)
                {
                    rb.velocity = Vector3.zero;
                    i = 0;
                    Debug.Log("That Happened");
                }
            }
             
        }
        else
        {
            Vector3 pos = transform.position;
            Vector3 dir = currentTarget.transform.position - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector2 force = transform.right * moveSpeed;
            rb.AddForce(force);
            alreadyIterated = false;
        }

        Debug.Log(currentTarget);

        //TANK FIRE

        float currentDistanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);

        if(currentDistanceFromPlayer <= 7)
        {
            cannon.GetComponent<tankFireScript>().aimCannon(player);
            cannon.GetComponent<tankFireScript>().fireCannon();
        }

        if(health <= 0)
        {
            gameStats.addScore(100);
            Application.LoadLevel(2);
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Hit");

        if (col.tag == "bullet")
        {
            col.gameObject.SetActive(false);
            gameStats.addScore(10);
            health--;
        }
    }
}
