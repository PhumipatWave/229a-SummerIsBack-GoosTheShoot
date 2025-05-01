using UnityEngine;
using System.Collections;

public class checkpoint_script : MonoBehaviour
{
        public GameObject checkPointOne;
        public GameObject checkPointTwo;
        public GameObject checkPointThree;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                StartCoroutine(CheckPointOne());
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                StartCoroutine(CheckPointTwo());
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                StartCoroutine(CheckPointThree());
            }
        }

        IEnumerator CheckPointOne()
        {
            checkPointOne.SetActive(true);
            yield return new WaitForSeconds(2f);
            checkPointOne.SetActive(false);
        }

        IEnumerator CheckPointTwo()
        {
            checkPointTwo.SetActive(true);
            yield return new WaitForSeconds(2f);
            checkPointTwo.SetActive(false);
        }

        IEnumerator CheckPointThree()
        {
            checkPointThree.SetActive(true);
            yield return new WaitForSeconds(2f);
            checkPointThree.SetActive(false);
        }
}
