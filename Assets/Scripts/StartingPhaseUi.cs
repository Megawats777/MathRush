using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartingPhaseUi : MonoBehaviour
{

    // Element references
    [SerializeField]
    private Text statusText;


    public void hide(bool withDelay)
    {
        if (!withDelay)
            transform.localScale = Vector3.zero;
        else
            Invoke("hideProcess", 0.85f);
    }

    public void show()
    {
        transform.localScale = Vector3.one;
    }


    private void hideProcess()
    {
        transform.localScale = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Update status text
    public void updateStatusText(int startCount)
    {
        if (startCount > 0)
            statusText.text = startCount.ToString();
        else if (startCount == 0)
            statusText.text = "GO!";
    }


}
