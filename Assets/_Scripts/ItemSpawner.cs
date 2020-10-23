using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject PotionPrefab;

    public GameObject SmallGoldPrefab;
    public GameObject MediumGoldPrefab;
    public GameObject LargeGoldPrefab;



    // Start is called before the first frame update
    void Start()
    {
        //choose a random item that we will spawn
        int spawnObject = Random.Range(0,4);
        switch (spawnObject)
        {
            case 0:
                //spawn a potion
                Instantiate(PotionPrefab);
                break;
            case 1:
                //spawn a small gold
                Instantiate(SmallGoldPrefab);
                break;
            case 2:
                //spawn a medium gold
                Instantiate(MediumGoldPrefab);
                break;
            case 3:
                //sawn a large gold
                Instantiate(LargeGoldPrefab);
                break;
            default:
                break;
        }
    }

}
