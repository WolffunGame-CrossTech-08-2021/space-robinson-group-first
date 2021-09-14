using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Sprite[] cursorSprites;
    private Animator anim; 
    private Vector2 cursorPosition;

    void Start()
    {
        Cursor.visible = false;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        anim.SetBool("LeftMouseClick", Input.GetMouseButtonDown(0));

        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
    }
}
