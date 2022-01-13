using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    private CubePos nowCube = new CubePos(0, 1, 0);
    public float cubeChangePlaceSpeed = 0.5f;
  
    private Rigidbody allCubesRb;

    private bool IsLose;

    private Coroutine showCubeToPlace;

    public GameObject cubeToCreate, allCubes;


    private float screen;


    public GameObject stiv;
    private Rigidbody stivRb;
    private float stivJump = 10f;


    private void Start()
    {

        stivRb = stiv.GetComponent<Rigidbody>();

        screen = Screen.width;
        allCubesRb = allCubes.GetComponent<Rigidbody>();
        showCubeToPlace = StartCoroutine(ShowCubePlace());

    }

    private void Update()
    {
        int i = 0;

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Input.mousePosition.x > screen / 2)
            {
                if (nowCube.x <= 5) /* бпелеммн */
                {
                    SpawnPositions(++nowCube.x, nowCube.y, nowCube.z);
                    MoveStiv(stiv.transform.position.x + 1, stiv.transform.position.y, stiv.transform.position.z);
                }
            }
            else
            {
                if (nowCube.x >= -5)  /*бпелеммн*/
                {
                    SpawnPositions(--nowCube.x, nowCube.y, nowCube.z);
                    MoveStiv(stiv.transform.position.x - 1, stiv.transform.position.y, stiv.transform.position.z);
                }
            }
        }

        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > screen / 2 || Input.mousePosition.x > screen / 2)
            {
                Debug.Log(1);
                ShowCubePlace();
            }
            else
            {
                Debug.Log(2);
            }

            i++;
        }


        /*if(/*Input.GetMouseButtonDown(0) || Input.touchCount > 0 &&*//* !IsLose*//*cubeToPlace != null*//*)
        {
#if !UNITY_EDITOR
            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;
#endif
            GameObject newCube = Instantiate(cubeToCreate, cubeToPlace.position, Quaternion.identity) as GameObject;

            newCube.transform.SetParent(allCubes.transform);
            nowCube.setVector(cubeToPlace.position);
            allCubesPositions.Add(nowCube.getVector());

            allCubesRb.isKinematic = true;
            allCubesRb.isKinematic = false;

            *//*SpawnPositions();*//*
        }

        if (!IsLose && allCubesRb.velocity.magnitude > 0.1f)
        {
            Destroy(cubeToPlace.gameObject);
            IsLose = true;
            StopCoroutine(showCubeToPlace);
        }*/

    }

    IEnumerator ShowCubePlace()
    {
        while (true)
        {

            MoveStiv(stiv.transform.position.x, stiv.transform.position.y + 2, stiv.transform.position.z);

            SpawnPositions(nowCube.x, ++nowCube.y, nowCube.z);

            yield return new WaitForSeconds(cubeChangePlaceSpeed);
        }
        
    }

    private void SpawnPositions(int x, int y, int z)
    {
        Vector3 newPosition = new Vector3(x, y, z);

        GameObject newCube = Instantiate(cubeToCreate, newPosition, Quaternion.identity) as GameObject;

        newCube.transform.SetParent(allCubes.transform);
        nowCube.setVector(newPosition);
    }

    private void MoveStiv(float x, float y, float z)
    {
        stiv.transform.position = new Vector3(x, y, z);
    }

    /*private bool isPositionEmpty(Vector3 target_pos)
    {
        if (target_pos.y == 0)
            return false;

        foreach (Vector3 pos in allCubesPositions)
        {
            if (pos.x == target_pos.x && pos.y == target_pos.y && pos.z == target_pos.z)
                return false;
        }

        return true;
        
    }*/

}

struct CubePos
{
    public int x, y, z;

    public CubePos(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 getVector()
    {
        return new Vector3(x, y, z);
    }

    public void setVector(Vector3 pos)
    {
        x = Convert.ToInt32(pos.x);
        y = Convert.ToInt32(pos.y);
        z = Convert.ToInt32(pos.z);
    }

}