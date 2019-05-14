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
        [SerializeField] private GameObject leaderboardElementPrefab;
        [SerializeField] private RectTransform leaderboardContainer;
        [SerializeField] private ScrollRect leaderboardScrollRect;
        [SerializeField] private LeaderboardPool leaderboardPool;

        private void Start()
        {
            SpawnLeaderboardElements();
            StartCoroutine(SetThePos());
        }

        IEnumerator SetThePos()
        {
            yield return new WaitForEndOfFrame();

            float totalHeight = leaderboardContainer.sizeDelta.y;
            float heightEachElement = totalHeight / maxElements;
            int correctedIndex = startElementIndex - 1;

            float containerYPos = heightEachElement * correctedIndex;
            leaderboardContainer.anchoredPosition = new Vector2(0, containerYPos);
        }

        void SpawnLeaderboardElements()
        {
            for (int i = 0; i < maxElements; i++)
            {
                GameObject element = leaderboardPool.GetElementFromPool();
                element.name = "Element [" + (i + 1) + "]";
                element.SetActive(true);
                element.transform.SetParent(leaderboardContainer.transform);
                element.GetComponent<LeaderboardElement>().SetLeaderboardDetails("" + (i + 1),
                "Swapnil " + i, "" + (maxElements - i));
            }
        }
    }
}
