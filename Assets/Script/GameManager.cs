using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block
{
    public Transform blockTransform;
    public BlockColor color;
}

public enum BlockColor
{
    White = 0,
    Red = 1,
    Green = 2,
    Blue = 3
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance { set; get; }

    private float blockSize = 0.25f;

    public Block[,,] blocks = new Block[20, 20, 20];
    public GameObject blockPrefab;

    public BlockColor selectedColor;
    public Material[] blockMaterials;

    private GameObject foundationObject;
    private Vector3 blockOffset;
    private Vector3 foundationCenter = new Vector3(1.25f, 0f, 1.25f);
    private bool isDeleting;

	// Use this for initialization
	void Start () {
        Instance = this;
        foundationObject = GameObject.Find("Foundation");
        blockOffset = (Vector3.one * 0.5f) / 4;
        selectedColor = BlockColor.White;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 30.0f))
            {
                if (isDeleting)
                {
                    if (hit.transform.name != "Foundation")
                    {
                        Vector3 oldCubeIndex = BlockPosition(hit.point - (hit.normal * (blockSize - 0.01f)));
                        Destroy(blocks[(int)oldCubeIndex.x, (int)oldCubeIndex.y, (int)oldCubeIndex.z].blockTransform.gameObject);
                        blocks[(int)oldCubeIndex.x, (int)oldCubeIndex.y, (int)oldCubeIndex.z] = null;
                    }
                    return;
                }

                Vector3 index = BlockPosition(hit.point);

                int x = (int)index.x
                    , y = (int)index.y
                    , z = (int)index.z;

                if (blocks[x, y, z] == null)
                {
                    GameObject go = CreateBlock();
                    PositionBlock(go.transform, index);

                    blocks[x, y, z] = new Block
                    {
                        blockTransform = go.transform,
                        color = selectedColor
                    };
                }
                else
                {
                    GameObject go = CreateBlock();

                    Vector3 newIndex = BlockPosition(hit.point + (hit.normal * blockSize));
                    blocks[(int)newIndex.x, (int)newIndex.y, (int)newIndex.z] = new Block
                    {
                        blockTransform = go.transform,
                        color = selectedColor
                    };
                    PositionBlock(go.transform, newIndex);
                }
            }
        }
	}

    private GameObject CreateBlock()
    {
        GameObject go = Instantiate(blockPrefab) as GameObject;
        go.GetComponent<Renderer>().material = blockMaterials[(int)selectedColor];
        go.transform.localScale = Vector3.one * blockSize;
        return go;
    }

    public GameObject CreateBlock(int x, int y, int z, Block b)
    {
        GameObject go = Instantiate(blockPrefab) as GameObject;
        go.GetComponent<Renderer>().material = blockMaterials[(int)b.color];
        go.transform.localScale = Vector3.one * blockSize;

        b.blockTransform = go.transform;
        blocks[x, y, z] = b;

        PositionBlock(b.blockTransform, new Vector3(x, y, z));

        return go;
    }

    private Vector3 BlockPosition(Vector3 hit)
    {
        int x = (int)(hit.x / blockSize);
        int y = (int)(hit.y / blockSize);
        int z = (int)(hit.z / blockSize);

        return new Vector3(x,y,z);
    }

    public void PositionBlock(Transform t, Vector3 index)
    {
        t.position = ((index * blockSize) + blockOffset) + (foundationObject.transform.position - foundationCenter);
    }

    public void ChangeBlockColor(int color)
    {
        selectedColor = (BlockColor)color;
    }

    public void ToggleDelete()
    {
        isDeleting = !isDeleting;
    }

    public void ResetGrid()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int k = 0; k < 20; k++)
                {
                    if (blocks[i, j, k] == null)
                        continue;

                    Destroy(blocks[i, j, k].blockTransform.gameObject);
                    blocks[i, j, k] = null;
                }
            }
        }
    }

}
