using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ThienMonoBehaviour
{
    [SerializeField] public Transform holder;


    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadPrefabs();
    }

    protected virtual void LoadHolder()
    {
        if(this.holder!=null)return;
        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name+": LoadHolder" , gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count>0)return;
        Transform prefabs  = transform.Find("Prefabs");
        foreach(Transform prefab in prefabs)
        {
                this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

        Debug.LogWarning(transform.name+": LoadPrefabs" , gameObject);
    }


    protected virtual void HidePrefabs()
    {
        foreach(Transform prefab in this.prefabs )
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual void Spawn(string prefabName ,Vector3 spawnPos ,Quaternion spawnRot)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab ==null) 
        {
            Debug.LogWarning(": Prefab not Found" +prefabName); 
        }
        this.Spawn(prefab,spawnPos,spawnRot);
    }


    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {
    

        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetLocalPositionAndRotation(spawnPos,spawnRot);
        newPrefab.parent = this.holder;
        return newPrefab;

    }



    protected virtual Transform GetPrefabByName(string PrefabName)
    {
        foreach(Transform prefab in this.prefabs)
        {
            if(prefab.name ==PrefabName)
            return prefab;
        }
        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform poolObj in this.poolObjs)
        {   

            if (poolObj == null) continue;
            if(prefab.name ==poolObj.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }

        }
        Transform newPrefab = Instantiate(prefab); // place spawn
        newPrefab.name = prefab.name;
        return newPrefab;


    }

    public virtual  void Despawn(Transform obj)
    {
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
    
    
        public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        return this.prefabs[rand];
    }
    
}
