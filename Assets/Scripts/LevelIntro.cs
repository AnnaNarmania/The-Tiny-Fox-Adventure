using UnityEngine;
using System.Collections;

public class LevelIntro : MonoBehaviour
{
    [SerializeField] private float delay;

    void Start()
    {
        StartCoroutine(HideIntro());
    }

    IEnumerator HideIntro()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}