using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardPool : MonoBehaviour
{
    private GameObject leaderboardElementPrefab;

    private Stack<GameObject> inActiveLeaderboardElementList;

    private void Awake()
    {
        leaderboardElementPrefab = (GameObject)Resources.Load("LeaderboardElement");

        inActiveLeaderboardElementList = new Stack<GameObject>();

        for (int i = 0; i < 10; i++)
        {
            GameObject element = Instantiate(leaderboardElementPrefab, transform);
            element.SetActive(false);
            inActiveLeaderboardElementList.Push(element);
        }
    }

    public GameObject GetElementFromPool()
    {
        GameObject element;
        if (inActiveLeaderboardElementList.Count > 0)
        {
            return inActiveLeaderboardElementList.Pop();
        }

        element = Instantiate(leaderboardElementPrefab, transform);
        return element;
    }

    public void SendElementToPool(GameObject element)
    {
        inActiveLeaderboardElementList.Push(element);
        element.SetActive(false);
    }


}
