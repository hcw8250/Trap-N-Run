using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool IsBeingHeld = false;

    // Update is called once per frame
    void Update()
    {
        if (IsBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }

    private void onMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            IsBeingHeld = true;
        }
    }

    private void onMouseUp()
    {
        IsBeingHeld = false;
    }

 
}
