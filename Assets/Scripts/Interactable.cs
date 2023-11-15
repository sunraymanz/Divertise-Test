using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] InteractUI uiToken;
    // Start is called before the first frame update
    void Start()
    {
        uiToken = FindObjectOfType<InteractUI>();
    }

    // Update is called once per frame
    void Update()
    {      
        ChestInteract();
    }

    public void ShowIcon() 
    {
        uiToken.SetUI(gameObject,true);
    }

    public void HideIcon()
    {
        uiToken.SetUI(gameObject, false);
    }

    public void ChestInteract() 
    {
        //Check if player touch and interact with it
        if (Input.GetKeyDown(KeyCode.E) && uiToken.iconToken.active)
        {
            //Open and Drop item
            GetComponentInParent<Animator>().SetBool("OpenChest",true); ;
            HideIcon();
            Invoke(nameof(DropItem),0.5f);
            FindObjectOfType<AirDropSystem>().SpawnNewChest(3f);
            Destroy(GetComponentInParent<Rigidbody2D>().gameObject, 2f);
            gameObject.SetActive(false);
        }
    }

    void DropItem() 
    {
        GameObject temp = Instantiate(FindObjectOfType<ItemSystem>().GetRandomItem(), transform.position + Vector3.up, Quaternion.identity);
        temp.AddComponent<PolygonCollider2D>();
        temp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
    } 

}
