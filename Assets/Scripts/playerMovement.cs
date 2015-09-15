using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private Camera gCam;
    private Vector2 mousePos;
    private Rigidbody2D rb;
    private Vector2 targetPos;
    private float timeToFire;
	private GameObject tempHolder;
    private objectPool oP;

    [SerializeField] GameObject player;
    [SerializeField] GameObject bullet;
    [SerializeField] float moveSpeed;

	// Use this for initialization
	void Start () 
    {
        gCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        oP = GetComponent<objectPool>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseHandler();

            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Vector3.Distance(transform.position, targetPos) < 1)
        {
            rb.velocity = Vector3.zero;
        }

        timeToFire--;

        //Debug.Log("Target Position: " +targetPos);
        //Debug.Log("Player Position: " +transform.position);

	
	}

    private Vector3 mouseHandler()
    {
        RaycastHit2D hit = Physics2D.Raycast(gCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null)
        {

            Debug.Log(hit.collider.tag);


            if (hit.collider.tag == "ground")
            {
                rb.velocity = Vector3.zero;
                /*Vector3 targetPosition = gCam.ScreenToWorldPoint(Input.mousePosition);

                

                Debug.Log(targetPosition);

                Debug.DrawLine(targetPosition, player.transform.position);*/

                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                if (Vector3.Distance(transform.position, dir) > 1)
                {
                    rb.AddForce(transform.right * moveSpeed);
                }

                Debug.DrawLine(pos, dir);

                return dir;

            }
            if (hit.collider.tag == "enemy" && timeToFire <= 0)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                timeToFire = 10;

                //Debug.Log(oP.GetFromPool().gameObject.name);

                GameObject temp = oP.GetFromPool();

                temp.SetActive(true);
                temp.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                temp.transform.rotation = transform.rotation;
                temp.GetComponent<bulletScript>().fireBullet();
            }

            else
                return Vector3.zero;
        }

        return Vector3.zero;
    
    }
}
