using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public GameObject Panel;
    
    public void HidePanel()
    {
        Panel.SetActive(false);
    }
}
