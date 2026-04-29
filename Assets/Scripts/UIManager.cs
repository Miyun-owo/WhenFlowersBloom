using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] MenuList;
    public GameObject[] Section1_Quiz;
    public GameObject[] Section1_Ans;
    public GameObject[] Section2;
    public GameObject[] Section3;
    void SetObjectsActive(GameObject[] objects, bool state)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(state);
        }
    }
    public void Homepage()
    {
        SetObjectsActive(MenuList, true);
        SetObjectsActive(Section1_Quiz, false);
        SetObjectsActive(Section2, false);
        SetObjectsActive(Section3, false);
    }

    public void Active1()
    {
        SetObjectsActive(MenuList, false);
        SetObjectsActive(Section1_Quiz, true);
        SetObjectsActive(Section2, false);
        SetObjectsActive(Section3, false);
    }

    public void Active1_1()
    {
        SetObjectsActive(Section1_Quiz, false);
        SetObjectsActive(Section1_Ans, true);
    }

    public void Active2()
    {
        SetObjectsActive(MenuList, false);
        SetObjectsActive(Section1_Quiz, false);
        SetObjectsActive(Section2, true);
        SetObjectsActive(Section3, false);
    }

    public void Active3()
    {
        SetObjectsActive(MenuList, false);
        SetObjectsActive(Section1_Quiz, false);
        SetObjectsActive(Section2, false);
        SetObjectsActive(Section3, true);
    }
}
