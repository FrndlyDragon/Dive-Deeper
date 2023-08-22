using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Assertions;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class InventorySlot : MonoBehaviour
{
    public InventoryItem item;
    public Image img;
    public Image bg;
    public Button btn;

    public Color baseColor = Color.grey;
    public Color selectedColor = Color.white;


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Assert.IsNotNull(item, "InventoryItem is null");
        Assert.IsNotNull(img, "Image is null");
        Assert.IsNotNull(bg, "Background Image is null");
        Assert.IsNotNull(btn, "Button is null");
#endif

        btn.onClick.AddListener(() =>
        {
            GameManager.Instance.selectedItem = item;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (item != null && item == GameManager.Instance.selectedItem)
        {
            bg.color = selectedColor;
        }
        else
        {
            bg.color = baseColor;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(InventorySlot))]
public class InventorySlotEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Update"))
        {
            InventorySlot slot = (InventorySlot)target;
            Image image = slot.img;
            image.sprite = slot.item.sprite;
            image.color = Color.white;

            slot.bg.color = slot.baseColor;

            EditorUtility.SetDirty(slot);
            EditorUtility.SetDirty(image);
            EditorUtility.SetDirty(slot.bg);
        }
    }
}
#endif