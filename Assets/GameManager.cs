using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject blockPrefab;

    private GameObject foundationObject;

    private Vector3 blockOffset = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 foundationCenter = new Vector3(2.5f, 0, 2.5f);

	// Use this for initialization
	void Start () {
        foundationObject = GameObject.Find("Foundation");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30.0f))
            {
                GameObject go = Instantiate(blockPrefab) as GameObject;
                go.transform.position = hit.point;
            }
        }
	}
}
