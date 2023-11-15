using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public Sprite sprite;

    public Item( Sprite sprite)
    {
        this.sprite = sprite;
    }
    void FixedUpdate()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if touch by player
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {         
            FindObjectOfType<InventorySystem>().Additem(gameObject);
        }
    }
}
