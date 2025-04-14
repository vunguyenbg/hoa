using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yoolax.Framework;
using System.Linq;

public class ModelUIManager : SingletonNormal<ModelUIManager>
{
    private float padding = 10f;
    private int offsetX = 1000;
    [SerializeField] private int count = 0;
    //[SerializeField] private string itemPath = "ItemUI/ItemUI";
    //[ShowInInspector] private Dictionary<string, ItemUIBase> dicModel = new Dictionary<string, ItemUIBase>();

    [SerializeField] private List<ModelUIList> lstModelUIList = new List<ModelUIList>();
    private ModelUIList ModelUIList;

    public void GetRenderTexture(string itemPath, string path, string id, out ItemUIBase itemUIBase, out bool firstSpawn)
    {
        firstSpawn = false;
        itemUIBase = null;
        ModelUIList = GetModelUIList(itemPath);

        if (ModelUIList == null)
        {
            Debug.LogError("Can't find ModelUIList: ItemPath: " + itemPath);
            return;
        }

        itemUIBase = GetHeroUI(path, id);
        if (itemUIBase != null)
        {
            itemUIBase.gameObject.SetActive(true);
            itemUIBase.AddCountShow();
        }
        else
        {
            itemUIBase = Spawn(path, id);
            if (itemUIBase != null)
            {
                itemUIBase.gameObject.SetActive(true);
                itemUIBase.AddCountShow();
                firstSpawn = true;
            }
            else
            {
                Debug.LogError("Can't find hero path: " + path);
            }
        }
    }

    ModelUIList GetModelUIList(string itemPath)
    {
        return lstModelUIList.Where(item => item.itemPath.Equals(itemPath)).FirstOrDefault();
    }

    ItemUIBase GetHeroUI(string path, string id)
    {
        string key = path + id;
        ItemUIBase itemUI = null;
        ModelUIList.dicModel.TryGetValue(key, out itemUI);
        return itemUI;
    }

    ItemUIBase Spawn(string path, string id)
    {
        string key = path + id;
        GameObject obj = Resources.Load<GameObject>(ModelUIList.itemPath);
        if (obj != null)
        {
            ItemUIBase itemUIBase = Instantiate(obj).GetComponent<ItemUIBase>();
            itemUIBase.transform.SetParent(ModelUIList.transform);
            if (itemUIBase != null)
            {
                itemUIBase.LoadData(path);
                itemUIBase.SetRenderTexture(new RenderTexture(1024, 1024, 24));
                ModelUIList.dicModel.Add(key, itemUIBase);
            }
            count += 1;
            itemUIBase.transform.position = new Vector3(offsetX + (count * padding), 0, 0);
            return itemUIBase;
        }
        return null;

    }

    public void HideModel(string path, string id)
    {
        ItemUIBase heroUI = GetHeroUI(path, id);
        if (heroUI != null)
        {
            heroUI.RemoveCountShow();
        }
    }


}
