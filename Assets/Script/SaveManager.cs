using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public GameObject saveMenu;
    public GameObject confirmMenu;

    public Transform saveList;
    public GameObject savePrefab;

    private bool isSaving;

    public void OnSaveMenuClick()
    {
        saveMenu.SetActive(true);
    }

    public void OnSaveClick()
    {
        saveMenu.SetActive(false);
        confirmMenu.SetActive(true);
        isSaving = true;
    }

    public void OnLoadClick()
    {
        saveMenu.SetActive(false);
        confirmMenu.SetActive(true);
        isSaving = false;
    }

    public void OnCancelClick()
    {
        saveMenu.SetActive(false);
    }

    public void OnConfirmOk()
    {
        if (isSaving)
            Save();
        else
            Load();

        confirmMenu.SetActive(false);
    }

    public void OnConfirmCancel()
    {
        confirmMenu.SetActive(false);
    }

    private void Save()
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

    }

    private void Load()
    {
        string save = PlayerPrefs.GetString("TEST");
        string[] blockData = save.Split('%');

        for (int i = 0; i < blockData.Length - 1; i++)
        {
            string[] currentBlock = blockData[i].Split('|');
            int x = int.Parse(currentBlock[0]);
            int y = int.Parse(currentBlock[1]);
            int z = int.Parse(currentBlock[2]);

            int c = int.Parse(currentBlock[3]);

            Block b = new Block() { color = (BlockColor)c };

            GameManager.Instance.CreateBlock(x, y, z, b);
        }
    }
}
