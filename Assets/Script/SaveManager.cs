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
        string saveData = "";

        Block[,,] b = GameManager.Instance.blocks;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    Block currentBlock = b[i, j, k];

                    if (currentBlock == null)
                        continue;

                    saveData += i.ToString() + "|" +
                        j.ToString() + "|" +
                        k.ToString() + "|" +
                        ((int)currentBlock.color).ToString() + "%";

                }
            }
        }

        PlayerPrefs.SetString("TEST", saveData);

        confirmMenu.SetActive(false);
    }

    public void OnConfirmCancel()
    {
        confirmMenu.SetActive(false);
    }
}
