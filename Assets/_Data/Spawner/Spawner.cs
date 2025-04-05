using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : TienMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs = new();
    [SerializeField] protected List<Transform> poolObjs = new();
    protected Transform holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    public virtual Transform Spawn(string prefabName, Vector3 position)
    {
        Transform prefab = GetPrefabByName(prefabName);
        if (prefab == null) return null;
        return this.Spawn(prefab, position);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 position)
    {
        Transform newPrefab = this.GetObjFromPool(prefab);
        if (newPrefab == null)
        {
            newPrefab = Instantiate(prefab, position, Quaternion.identity);
            newPrefab.name = prefab.name;
        }
        newPrefab.SetParent(this.holder);
        return newPrefab;
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform obj in this.poolObjs)
        {
            if (obj.name == prefab.name)
            {
                this.poolObjs.Remove(obj);
                return obj;
            }
        }
        return null;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabsHolder = transform.Find("Prefabs");
        foreach (Transform prefab in prefabsHolder)
        {
            this.prefabs.Add(prefab);
        }
        this.HideAllPrefabs();
        Debug.LogWarning($"{transform.name}: LoadPrefabs", gameObject);
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning($"{transform.name}: LoadHolder", gameObject);
    }

    protected virtual void HideAllPrefabs()
    {
        foreach (var prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
}
