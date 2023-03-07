using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Sprite> myInventory = new List<Sprite>(); // All sprites of items added to inventory
    [SerializeField] private GameObject inventoryCanvas;                    // The canvas that will be shown to player
    [SerializeField] private Transform inventoryPanel;                      // The parent that will hold the items
    [SerializeField] private int addHeight = 180;                           // Default fixed value for adding height
    [SerializeField] private float xWidth;                                  // Get initial x width first, to reuse when adding height

    // Start is called before the first frame update
    void Start()
    {
        xWidth = inventoryPanel.GetComponent<RectTransform>().sizeDelta.x;
        inventoryPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(xWidth, 200f);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventoryCanvas();
    }

    // Press I to toggle showing and hiding canvas
    private void ToggleInventoryCanvas()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryCanvas.activeSelf == false)
            {
                ShowInventory();
            }
            else
            {
                HideInventory();
            }
        }
    }
    private void ShowInventory()
    {
        inventoryCanvas.SetActive(true);
    }
    private void HideInventory()
    {
        inventoryCanvas.SetActive(false);
    }
    // Will be called in DialogueScript to add
    public void AddToInventory(Sprite item)
    {
        if (!myInventory.Contains(item))
        {
            myInventory.Add(item);

            // Create new prefab for instantiating in inventory
            GameObject newItem = new GameObject();
            newItem.AddComponent<Image>();
            // Set image in inventory to what was added (item)
            newItem.GetComponent<Image>().sprite = item;

            // Instantiate this gameobject on runtime
            Instantiate(newItem, inventoryPanel);

            // Increase viewport height everytime 2 items added, otherwise cannot scroll
            if (myInventory.Count % 2 == 0)
            {
                float yHeight = inventoryPanel.GetComponent<RectTransform>().sizeDelta.y + addHeight;
                inventoryPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(xWidth, yHeight);
            }
        }
    }

}
