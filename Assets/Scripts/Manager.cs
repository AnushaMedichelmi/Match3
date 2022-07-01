using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Stack<GameObject> gameObjects = new Stack<GameObject>();
    public BallCreation ballCreation;
    Vector3[] direction =
        {new Vector3(-1,0,0),
        new Vector3(1,0,0),
        new Vector3(0,1,0),
        new Vector3(0,-1,0),
        new Vector3(1,1,0),
        new Vector3(-1,-1,0),
        new Vector3(1,-1,0),
        new Vector3(-1,1,0)};
    private static Manager instance;

    public static Manager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("Manager").GetComponent<Manager>();
            }
            return instance;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            while (gameObjects.Count > 0)
            {
                GameObject item = gameObjects.Pop();
                ballCreation.CreateBall(item.gameObject.transform.position);
                Destroy(item);

            }

        }
    }
    public bool CheckingList(GameObject obj)
    {
        Debug.Log("Checking: " + gameObjects.Count);
        if (gameObjects.Count == 0)
            return true;
        else
        {
            GameObject top = gameObjects.Peek();
             //Material sprite1 = top.GetComponent<MeshRenderer>().material;
            SpriteRenderer sprite1 = top.GetComponent<SpriteRenderer>();
            // Material sprite2 = obj.GetComponent<MeshRenderer>().material;
            SpriteRenderer sprite2 = top.GetComponent<SpriteRenderer>();
          
            
            for (int i = 0; i < direction.Length; i++)
            {

                if (top.transform.position == (obj.transform.position + direction[i]) && sprite1.sprite.name == sprite2.sprite.name)
                {
                    Debug.Log(sprite1.sprite + "  " + sprite2.sprite);
                    return true;
                }
            }

        }
        return false;
    }
    public void AddToList(GameObject obj)
    {
        gameObjects.Push(obj);
        Debug.Log(gameObjects.Count);
    }
    public void RemoveFromList()
    {
        gameObjects.Pop();

    }
}
