using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_dialogObject;
    [SerializeField]
    private TMP_Text m_dialogText;
    // Start is called before the first frame update
    void Start()
    {
        m_dialogObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallShowDialog(string text)
    {
        StartCoroutine(ShowDialog(text));
    }

    private IEnumerator ShowDialog(string text)
    {
        m_dialogText.text = text;
        m_dialogObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        m_dialogObject.SetActive(false);
    }
}
