using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMUIManager : MonoBehaviour
{
    private static CMUIManager instance = null;
    public static CMUIManager Instance;
    

    [Header("0~1,Timer")]
    [Header("2.Item")]
    [Header("3~13.AbilityVar")]

    public GameObject[] UIGameObject;

    [SerializeField] float[] startTime;
    [SerializeField] float[] midleTime;

    [SerializeField] float darkSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        #region BlinkSetUp
        int size = UIGameObject.Length;
        
        startTime = new float[size];
        midleTime = new float[size];
        int count = 0;
        
        if (instance == null)
        {
            instance = new CMUIManager();
            Instance = instance;
        }
        else
            Destroy(instance.gameObject);

        startTime[0] = 2f;
        midleTime[0] = 3f;

        startTime[1] = 2f;
        midleTime[1] = 3f;

        startTime[2] = 6f;
        midleTime[2] = 4f;

        startTime[3] = 4f;
        midleTime[3] = 3f;

        StartCoroutine(BlinkSprite(startTime[0], midleTime[0], 0,1));

        StartCoroutine(BlinkSprite(startTime[2], midleTime[2], 2));

        StartCoroutine(BlinkSprite(startTime[3], midleTime[3], 3,13));
        #endregion

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BlinckUI()
    {
        ;
    }
    #region Blink
    IEnumerator BlinkSprite(float _startTime, float _midleTime, int _num)
    {
        Image thisImage = UIGameObject[_num].GetComponent<Image>();

        yield return new WaitForSeconds(_startTime);
        while (true)
        {

            int i = 0;
            int maxi = Random.Range(3, 8);
            while (i < maxi)
            {
                float setA = 1f;
                while (true)
                {
                    if (setA <= 0f)
                        break;
                    setA -= 0.1f * darkSpeed;
                    thisImage.color = new Color(1, 1, 1, setA);
                    yield return null;
                }
                setA = 0f;
                while (true)
                {
                    if (setA >= 1f)
                        break;
                    setA += 0.04f * darkSpeed;
                    thisImage.color = new Color(1, 1, 1, setA);
                    yield return null;

                }
                thisImage.color = new Color(1, 1, 1, 1);

                ++i;
            }
            yield return new WaitForSeconds(_midleTime);

        }
    }

    IEnumerator BlinkSprite(float _startTime, float _midleTime, int _num, int _num2)
    {
        int imageSize = _num2 - _num +1;
        Image[] thisImage = new Image[imageSize];
        for(int i = 0; i < imageSize; i++)
        {
            thisImage[i] = UIGameObject[_num + i].GetComponent<Image>();
        }

        yield return new WaitForSeconds(_startTime);
        while (true)
        {

            int i = 0;
            int maxi = Random.Range(3, 8);
            while (i < maxi)
            {
                float setA = 1f;
                while (true)
                {
                    if (setA >= 1f)
                        break;
                    setA += 0.04f * darkSpeed;
                    for (int j = 0; j < imageSize; j++)
                    {
                        thisImage[j].color = new Color(1, 1, 1, setA);
                    }

                    yield return null;
                }
                setA = 0f;
                while (true)
                {
                    if (setA >= 1f)
                        break;
                    setA += 0.04f * darkSpeed;
                    for (int j = 0; j < imageSize; j++)
                    {
                        thisImage[j].color = new Color(1, 1, 1, setA);
                    }

                    yield return null;

                }
                for (int j = 0; j < imageSize; j++)
                {
                    thisImage[j].color = new Color(1, 1, 1, 1);
                }

                ++i;
            }
            yield return new WaitForSeconds(_midleTime);

        }
    }
    #endregion
    
}