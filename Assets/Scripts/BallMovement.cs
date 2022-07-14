using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    bool ismousedown;
    Vector3 currentscale;
    void Start()
    {
        ismousedown = false;
        currentscale = transform.localScale;
    }


    private void OnMouseDown()
    {

        if (Manager.Instance.CheckingList(this.gameObject))
        {

            if (!ismousedown)
            {
                ismousedown = !ismousedown;
                Manager.Instance.AddToList(this.gameObject);
                Debug.Log(gameObject.name);
                // transform.localScale = Vector3.one;
                transform.localScale += new Vector3(0.5f, 0.5f, 0f);
            }

        }
        else if (ismousedown && Manager.Instance.gameObjects.Count == 1)
        {
            ismousedown = !ismousedown;
            transform.localScale = currentscale;
            Manager.Instance.RemoveFromList();
        }

        /*Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit hit;
        worldPosition.z = -1f;
       
        if (Physics.Raycast(worldPosition,Vector3.forward,out hit,100f))
        {
            Debug.Log(hit.collider.gameObject.name);
            //hit.collider.gameObject.transform.localScale+=
        }*/

    }


}
