using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ItemMaker : EditorWindow
{
    string root = "Assets/Data/Item";
    Type[] types;
    string[] typeNames;


    ScriptableObject temp;
    Editor inspector;
    int typeIndex;
    [MenuItem("Tools/ItemMaker")]
    public static void StartWindow()
    {
        GetWindow<ItemMaker>();
    }

    void OnEnable()
    {
        var list = TypeCache.GetTypesDerivedFrom<ItemData>().ToList();
        list.Insert(0, typeof(ItemData));
        types = list.ToArray();
        typeNames = types.Select(t => t.Name).ToArray();
        SetTemp(types[0]);
    }

    void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        typeIndex = EditorGUILayout.Popup("Item Type", typeIndex, typeNames);
        if (EditorGUI.EndChangeCheck())
            SetTemp(types[typeIndex]);

        using (new EditorGUILayout.VerticalScope("box"))
        {
            if (inspector != null) inspector.OnInspectorGUI();
        }

        if (GUILayout.Button("Create ItemData", GUILayout.Height(32)))
            CreateItem();
    }

    void SetTemp(Type _type)
    {
        DestroyTemp();
        if (_type == null) return;
        temp = ScriptableObject.CreateInstance(_type);
        inspector = Editor.CreateEditor(temp);
    }

    void DestroyTemp()
    {
        if (temp)
            DestroyImmediate(temp);
        if (inspector)
            DestroyImmediate(inspector);
        temp = null;
        inspector = null;
    }

    void CreateItem()
    {
        var t = types[typeIndex];
        var itemdata = temp as ItemData;

        if (itemdata == null) return;
        string path = $"{root}/{itemdata.itemType}/{itemdata.itemName}.asset";
        if (itemdata.itemType == ItemType.Equip)
        {
            EquipItemData equip = itemdata as EquipItemData;
            path = $"{root}/{equip.itemType}/{equip.equipType}/{equip.itemName}.asset";
        }


        ScriptableObject final = ScriptableObject.CreateInstance(t);
        string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
        temp.name = fileName;
        AssetDatabase.CreateAsset(final, path);
        EditorUtility.CopySerialized(temp, final);
        EditorUtility.SetDirty(final);
        AssetDatabase.SaveAssets();

    }
}
