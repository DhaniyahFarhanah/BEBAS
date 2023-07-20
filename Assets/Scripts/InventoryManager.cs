using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    GameObject selectedItem;

    GameObject collidedItem;

    /// <summary>
    /// Actual object, highlight object and if this slot is free or not
    /// </summary>
    public Dictionary<GameObject, KeyValuePair<GameObject, bool>> allItems;
    public List<GameObject> items;
    List<GameObject> itemsToHold;

    public GameObject inventory;

    public int currentIndex;

    private void Awake()
    {
        Instance = this;

        allItems = new Dictionary<GameObject, KeyValuePair<GameObject, bool>>();
        itemsToHold = new List<GameObject>();

        inventory.SetActive(false);

        foreach (var item in items)
        {
            allItems.Add(item.gameObject, new KeyValuePair<GameObject, bool>(item.transform.GetChild(0).gameObject, true));
            itemsToHold.Add(default);
        }

        allItems[items[currentIndex]].Key.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            //Open Inv
            inventory.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            //Close Inv
            inventory.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Delete))
        {
            SelectItem();

            //Drop item
            if (selectedItem != default)
            {
                int i = itemsToHold.IndexOf(selectedItem);

                items[i].GetComponent<Image>().sprite = default;
                allItems[items[i]] = new KeyValuePair<GameObject, bool>(allItems[items[i]].Key, true);
                itemsToHold[i] = default;

                selectedItem.transform.position = gameObject.transform.position;

                selectedItem.AddComponent<Rigidbody2D>();

                selectedItem.SetActive(true);
                selectedItem = default;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //prev
            allItems[items[currentIndex]].Key.SetActive(false);

            currentIndex--;
            currentIndex = currentIndex < 0 ? items.Count - 1 : currentIndex;

            allItems[items[currentIndex]].Key.SetActive(true);

            SelectItem();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //next
            allItems[items[currentIndex]].Key.SetActive(false);

            currentIndex++;
            currentIndex = currentIndex >= items.Count ? 0 : currentIndex;

            allItems[items[currentIndex]].Key.SetActive(true);

            SelectItem();
        }
    }

    public void PickObj(GameObject collidedItem)
    {
        //Pick Up Item
        int i = 0;
        foreach (var item in allItems)
        {
            if (item.Value.Value)
            {
                break;
            }

            i++;
        }

        items[i].GetComponent<Image>().sprite = collidedItem.GetComponent<ItemManager>().itemImage;
        allItems[items[i]] = new KeyValuePair<GameObject, bool>(allItems[items[i]].Key, false);
        itemsToHold[i] = collidedItem;

        collidedItem.SetActive(false);
        collidedItem = default;
    }

    void SelectItem()
    {
        if (!allItems[items[currentIndex]].Value)
        {
            selectedItem = itemsToHold[currentIndex];
        }
        else
        {
            selectedItem = default;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<ItemManager>() != default)
    //    {
    //        collidedItem = collision.gameObject;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.GetComponent<ItemManager>() != default)
    //    {
    //        collidedItem = default;
    //    }
    //}
}
