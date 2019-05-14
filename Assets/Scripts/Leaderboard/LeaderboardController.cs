using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LeaderboardSystem
{
    public class LeaderboardController : MonoBehaviour
    {
        [SerializeField] private int maxElements = 100;
        [SerializeField] private int startElementIndex = 50;
        [SerializeField] private GameObject leaderboardElementPrefab, leaderboardContainer;
        [SerializeField] private ScrollRect leaderboardScrollRect;
        [SerializeField] private LeaderboardPool leaderboardPool;

        private void Start()
        {
            SpawnLeaderboardElements();
            float fraction = (float)(maxElements - startElementIndex) / maxElements;
            leaderboardScrollRect.verticalNormalizedPosition = fraction;
        }

        void SpawnLeaderboardElements()
        {
            for (int i = 0; i < maxElements; i++)
            {

                GameObject element = leaderboardPool.GetElementFromPool();
                element.SetActive(true);
                element.transform.SetParent(leaderboardContainer.transform);
                element.GetComponent<LeaderboardElement>().SetLeaderboardDetails("" + i,
                "Swapnil " + i, "" + (maxElements - i));
            }
        }
    }
}
