using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 newMinPosition;
    public Vector2 newMaxPosition;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needText;
    public GameObject textObj;
    public string textToShow;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.CompareTag("Player"))
        {
            cam.minPosition = newMinPosition;
            cam.maxPosition = newMaxPosition;

            obj.transform.position += playerChange;
        }

        if(needText)
        {
            textObj.GetComponent<Text>().text = textToShow;
            StartCoroutine(ShowText());
        }
    }

    private IEnumerator ShowText()
    {
        textObj.GetComponent<EasyTween>().OpenCloseObjectAnimation();
        yield return new WaitForSeconds(1.5f);
        textObj.GetComponent<EasyTween>().OpenCloseObjectAnimation();
    }
}
