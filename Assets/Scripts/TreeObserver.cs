using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObserver : MonoBehaviour
{
    public CloudSpawner2 cloudSpawner;
    public TreeColider treeColider;

    public GameObject[] trees;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i< trees.Length; i++){
            trees[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
