using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    public GameObject roadPrefab;

    public ObjectPooler objectPooler;

    public Vector3 lastPos;
    private readonly float offset = 0.7071068f;

    private int roadCount = 0;

    // ReSharper disable Unity.PerformanceAnalysis
    public void CreateNewRoadPart()
    {
        //Debug.Log("New Road Part Created!");

        float chance = Random.Range(0, 100);

        Vector3 spawnPos;

        if(chance <= 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        //GameObject newRoad = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        GameObject newRoad = objectPooler.GetPooledObject();
        newRoad.transform.position = spawnPos;
        //newRoad.transform.Find("Crystal").gameObject.SetActive(false);
        newRoad.SetActive(true);

        lastPos = newRoad.transform.position;

        roadCount++;
        //print("ROAD COUNT: " + roadCount);

        if (roadCount % 5 == 0)
            newRoad.transform.Find("GoldCoin").gameObject.SetActive(true);
        /*else
            newRoad.transform.Find("Crystal").gameObject.SetActive(false);
    */}

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.canAppear)
        {
            //Invoke(nameof(CreateNewRoadPart), 0.18f);
            CreateNewRoadPart();
            GameManager.instance.canAppear = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateNewRoadPart();
        }*/
    }
}
