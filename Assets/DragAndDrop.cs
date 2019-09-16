using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;

    public GameObject selectionEffect;
    public GameObject deathEffect;

    private GameMaster gm;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gm.alive)
        {
            HandleMouse();
            HandleTouch();
        }
        else if (moveAllowed)
        {
            moveAllowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            if (deathEffect)
            {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            }
            gm.GameOver();
        }
    }

    void HandleTouch ()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (col == touchedCollider)
                {
                    if (selectionEffect)
                    {
                        Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    }
                    source.Play();
                    moveAllowed = true;
                }
            }

            if (touch.phase == TouchPhase.Moved && moveAllowed)
            {
                transform.position = new Vector2(touchPosition.x, touchPosition.y);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }

    void HandleMouse ()
    {
        bool isBtnDown = Input.GetMouseButton(0);
        if (isBtnDown & !moveAllowed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D touchedCollider = Physics2D.OverlapPoint(mousePos);
            if (col == touchedCollider)
            {
                if (selectionEffect)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                }
                source.Play();
                moveAllowed = true;
            }
        }
        if (moveAllowed && !isBtnDown)
        {
            moveAllowed = false;
        }

        if (moveAllowed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }        
    }
}
