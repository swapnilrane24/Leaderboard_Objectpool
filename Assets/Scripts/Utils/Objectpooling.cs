using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class Objectpooling<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected GameObject poolObject;
        protected Stack<GameObject> poolObjectStack;

        protected virtual void Awake()
        {
            
        }

        protected virtual void Initialize()
        {
            poolObjectStack = new Stack<GameObject>();

            for (int i = 0; i < 5; i++)
            {
                GameObject element = Instantiate(poolObject, transform);
                element.SetActive(false);
                poolObjectStack.Push(element);
            }
        }

        public GameObject GetElementFromPool()
        {
            GameObject element;
            if (poolObjectStack.Count > 0)
            {
                return poolObjectStack.Pop();
            }

            element = Instantiate(poolObject, transform);
            return element;
        }

        public void SendElementToPool(GameObject element)
        {
            poolObjectStack.Push(element);
            element.SetActive(false);
        }


    }
}