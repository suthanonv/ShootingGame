using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAnimation : MonoBehaviour
{
    public static ResultAnimation instance;
    public GameObject ResultType;
  [SerializeField]  public GameObject[] bar = new GameObject[0];
  [SerializeField] public GameObject[] button = new GameObject[0];

    [SerializeField] private float barAnimatLenght;
    [SerializeField] private float ButtonAnimatLenght;
    [SerializeField] private float TextActive;

    private void Awake()
    {
        instance = this;
    }

    public void RunAnimation()
    {
        StartCoroutine(TextAnims());
    }


         IEnumerator barAnim()
    {
        int count = 0;
        while(count < bar.Length)
        {
            yield return new WaitForSeconds(barAnimatLenght);
            bar[count].SetActive(true);
            count++;
        }
        StartCoroutine(ButtonAnima());
    }

      IEnumerator ButtonAnima()
    {
        int count = 0;
        while(count < button.Length)
        {
            yield return new WaitForSeconds(ButtonAnimatLenght);
            button[count].SetActive(true);
            count++;
        }
    }


    IEnumerator TextAnims()
    {
      yield  return new WaitForSeconds(TextActive);
        ResultType.SetActive(true);
        StartCoroutine(barAnim());
    }
}
