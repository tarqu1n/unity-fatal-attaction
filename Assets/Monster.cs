using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SpriteManager;

public class Monster : MonoBehaviour
{
    private SpriteManager spriteManager;
    private MonsterInfo monsterInfo;
    public GameObject deathEffect;

    private GameMaster gm;


    Vector2 targetPosition;
    void Start()
    {
        // get game master
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        // get random sprite with its selection animation
        spriteManager = transform.parent.gameObject.GetComponent<SpriteManager>();
        monsterInfo = spriteManager.GetRandom();

        GetComponent<SpriteRenderer>().sprite = monsterInfo.sprite;
        GetComponent<DragAndDrop>().selectionEffect = monsterInfo.selectionEffect;

    }

    void Update()
    {

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
}
