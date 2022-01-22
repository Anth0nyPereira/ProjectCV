using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsController : MonoBehaviour
{
    public List<GameObject> targets;
    public int maxTargets = 10;
  //  public GameObject[] targetUsed;
    public GameObject target;
    private int randomSpawnSpot;
    public Transform[] targetPos;
    public GameObject[] spawnspots;
    private int x = 0;

    // Start is called before the first frame update
    void Start()
    {
        targets = new List<GameObject>();
        randomSpawnSpot = Random.Range(0, targetPos.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i< maxTargets; i++)
        //{
        //    targets.Add(targetUsed[i]);
        //}
        TargetGen();
    }

    void TargetGen()
    {
        while (x <= 9)
        {
            randomSpawnSpot = Random.Range(0, targetPos.Length);

            //if(targetPos[x].transform.childCount <= 0)
            //{
                
               // Instantiate(target, targetPos[randomSpawnSpot].transform, false);
            //} else
            //{

            //}

            Instantiate(target, targetPos[x].position, Quaternion.Euler(-90, -90, 0));

            // Instantiate(target, targetPos[randomSpawnSpot].transform, false);
            x++;
        }
    }

    public void AddItem(GameObject newItem)
    {
        if (!this.isFull())
        {
            targets.Add(newItem);
        }
    }

    public void RemoveItem(GameObject item)
    {
        targets.Remove(item);
    }

    public bool isFull()
    {
        if (targets.Count >= maxTargets)
        {
            Debug.LogWarning("Full Targets!!");
            return true;
        }
        return false;
    }

    public List<GameObject> GetAllItems()
    {
        return targets;
    }
}
