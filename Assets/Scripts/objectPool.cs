using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class objectPool : MonoBehaviour {

	public GameObject bullet;
	public int pooledAmount = 10;
	public bool willGrow = true;

	public List<GameObject> pBullets;

	// Use this for initialization
	void Start () {

		pBullets = new List<GameObject>();
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject temp = (GameObject)Instantiate(bullet);
            temp.SetActive(false);
			pBullets.Add(bullet);
		}
	}

    public GameObject GetFromPool()
    {
        for(int i = 0; i < pBullets.Count; i++)
        {
            if(pBullets[i] == null)
            {
                GameObject temp = (GameObject)Instantiate(bullet);
                temp.SetActive(false);
                pBullets[i] = temp;
                return pBullets[i];
            }
            if(!pBullets[i].activeInHierarchy)
            {
                return pBullets[i];
            }
        }

        if(willGrow)
        {
            GameObject temp = (GameObject)Instantiate(bullet);
            pBullets.Add(temp);
            return temp;
        }

        return null;
    }
}
