using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public GameObject saveMenu;
    public GameObject confirmMenu;

    public Transform saveList;
    public GameObject savePrefab;

    public void OnSaveMenuClick()
    {
        saveMenu.SetActive(true);
    }

    public void OnSaveClick()
    {
        saveMenu.SetActive(false);
        confirmMenu.SetActive(true);
    }

    public void OnLoadClick()
    {
        saveMenu.SetActive(false);
        confirmMenu.SetActive(true);
    }

    public void OnCancelClick()
    {
        saveMenu.SetActive(false);
    }

    public void OnConfirmOk()
    {
        //save or load
        confirmMenu.SetActive(false);
    }

    public void OnConfirmCancel()
    {
        confirmMenu.SetActive(false);
    }




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
