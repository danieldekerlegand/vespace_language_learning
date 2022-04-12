using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.Extras;
using Valve.VR;
using Ensemble;

public class ENSEMBLE_UIHandler : MonoBehaviour
{
    public GameObject ensembleUI;
    public bool activeUI;
    public GameObject leftHand;
 
    public SteamVR_LaserPointer laserPointer;
    public Color hit_color;
    public Color miss_color;

    public string objectName;
    public EnsembleData data;



    void Start()
    { 
        activeUI = false;
        
        laserPointer.color = miss_color;
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void Display()
    {
        
        if (activeUI)
        {
            ensembleUI.SetActive(false);
            activeUI = false;
        } else if (!activeUI)
        {
            ensembleUI.SetActive(true);
            activeUI = true;
        }
    }

    private void Orientation()
    {
        ensembleUI.transform.SetParent(leftHand.transform);
        ensembleUI.transform.localEulerAngles = new Vector3(45f, 0f, 0f);
        ensembleUI.transform.localPosition = new Vector3(0.2f, 0.3f, 0.2f);
        ensembleUI.transform.localScale = new Vector3(0.0006f, 0.0006f, 0.0006f);
    }

    //LaserPointer functions overload:
    public void PointerClick(object sender, PointerEventArgs e)
    {
        EnsembleObject ensemble = e.target.GetComponent<EnsembleObject>();
        if (ensemble != null)
        {
            //The object is an Ensemble object
            Orientation();
            Display();
            objectName = gameObject.name;
            getCharacterData(objectName);
            //omekaPad.displayItem(voo.OmekaVirtualObjectID);
        }
        if (e.target.gameObject.layer == 5)
        {
            //layer of the UI: 5 
            Button button = e.target.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.Invoke();
            }
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        laserPointer.color = hit_color;
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        laserPointer.color = miss_color;
    }

    public void getCharacterData(string objectName)
    {
        Predicate searchPredicate = new Predicate();
        searchPredicate.First = objectName;
        List<Predicate> characterData = data.ensemble.get(searchPredicate);

        foreach (Predicate datum in characterData)
        {
            //Debug.LogFormat("First: { 0}, Second: { 1}, Category: { 0}, Type: { 2}, Value: { 3}", datum.First, datum.Second, datum.Category, datum.Type, datum.Value);
            string[] temp = new string[] { datum.First, datum.Second, datum.Category, datum.Type, "TEMP" };
            Debug.LogFormat("First: { 0}, Second: { 1}, Category: { 0}, Type: { 2}, Value: { 3}", temp);
        }
    }
}
