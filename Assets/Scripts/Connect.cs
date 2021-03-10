using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Connect : MonoBehaviour
{
    // Start is called before the first frame update
    public Button m_YourFirstButton;

    // public void setText(string text)
    // {
    //     Text txt = transform.Find("Text").GetComponent<Text>();
    //     text.text = text;
    // }
    void Start()
    {
        // Debug.Log("button");
        m_YourFirstButton.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }
}
