using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private Camera gCam;
    private Vector2 mousePos;
    private Rigidbody2D rb;

    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed;

	// Use this for initialization
	void Start () 
    {
        gCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseHandler();
        }
	
	}

    private void mouseHandler()
    {
        RaycastHit2D hit = Physics2D.Raycast(gCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit.collider != null)
        {
            if(hit.collider.tag == "ground")
            {
                rb.velocity = Vector3.zero;
                /*Vector3 targetPosition = gCam.ScreenToWorldPoint(Input.mousePosition);

                

                Debug.Log(targetPosition);

                Debug.DrawLine(targetPosition, player.transform.position);*/

                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                if(Vector3.Distance(transform.position, dir) > 1)
                {
                    rb.AddForce(transform.right * moveSpeed);
                }

                Debug.DrawLine(pos, dir);

            }
        }
    
    }
}
