using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    [SerializeField] List<Sprite> itemSpriteList;
    [SerializeField] GameObject itemPrefab;

    public GameObject GetRandomItem()
    {
        int temp = Random.Range(0, itemSpriteList.Count - 1);
        itemPrefab.GetComponent<SpriteRenderer>().sprite = itemSpriteList[temp];
        itemPrefab.GetComponent<Item>().id = temp;
        return itemPrefab;
    }
}
