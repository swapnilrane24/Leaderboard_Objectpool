using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace LeaderboardSystem
{
    public class LeaderboardController : MonoBehaviour
    {
        [SerializeField] private int maxElements = 100;
        [SerializeField] private int startElementIndex = 50;
        [SerializeField] private GameObject leaderboardElementPrefab, leaderboardContainer;
        [SerializeField] private ScrollRect leaderboardScrollRect;
        [SerializeField] private LeaderboardPool leaderboardPool;

        private float oldPos;
        private float tempInt;

        private void Start()
        {
            SpawnLeaderboardElements();
            tempInt = startElementIndex;
            if(tempInt > 10)
            {
                tempInt += (tempInt - 10) / 10;
            }

            if (tempInt > maxElements) tempInt = maxElements;

            float fraction = (float)(maxElements - tempInt) /maxElements;
            Debug.Log(fraction);
            leaderboardScrollRect.verticalNormalizedPosition = fraction;
            oldPos = leaderboardScrollRect.verticalNormalizedPosition;
        }

        void SpawnLeaderboardElements()
        {
            for (int i = 0; i < maxElements; i++)
            {
                GameObject element = leaderboardPool.GetElementFromPool();
                element.SetActive(true);
                element.transform.SetParent(leaderboardContainer.transform);
                element.GetComponent<LeaderboardElement>().SetLeaderboardDetails("" + (i + 1),
                "Swapnil " + i, "" + (maxElements - i));
            }
        }
    }
}
