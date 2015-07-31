using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private Camera gCam;
    private Vector2 mousePos;

    [SerializeField] GameObject player;

	// Use this for initialization
	void Start () 
    {
        gCam = Camera.main;
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
                Vector3 targetPosition = gCam.ScreenToWorldPoint(Input.mousePosition);

                Debug.Log(targetPosition);

                transform.LookAt(new Vector3(targetPosition.x, targetPosition.y, -10));

                Debug.DrawLine(targetPosition, player.transform.position);

            }
        }
    
    }
}
