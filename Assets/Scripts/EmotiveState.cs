using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ensemble;

public class EmotiveState : MonoBehaviour
{
    
    public Transform halo;
    public ParticleSystemRenderer haloParticleRenderer;

    private Cast cast = new Cast { 
        "Male Noble Player", 
        "Female Noble Player", 
        "Servant Player", 
		"Grace Huval",
		"Ralph Aucoin",
		"Francois LeBlanc",
		"Jean Billeaud",
		"Christophe Bertrand",
		"Dustin Gaspard",
		"Théo Arnaud",
		"Cora DeCuir",
		"Elizabeth Landry",
        "Charles Devillier",
        "Renee Hebert",
		"Victoria Guidry",
		"Adrianne Billedeau",
		"Jeanne Comeaux",
		"Mary Delahoussaye",
		"Celila Broussard",
		"Charles Devillie",
		"Claude Gaudet",
		"Amy Robichaux",
		"Elie Charpentier",
		"Jeanne Moutard",
		"Ralph Langlois",
		"Marie-Claire Savoie"
    };

    // Start is called before the first frame update
    void Start()
    {
        halo = gameObject.transform.GetChild(0);
    }

    public IEnumerator<object> RunApproachableUpdate()
    {
        yield return null;

        bool isApproachable = false;

        //Run Ensemble data to find out if this person is friends with the player.
        ENSEMBLE_UIHandler uiHandler = GameObject.Find("UIHandler").GetComponent<ENSEMBLE_UIHandler>();

        bool result;
        if (uiHandler.characterAvailable.TryGetValue(transform.parent.name, out result)) {
            isApproachable = result;
        }

        haloParticleRenderer = halo.GetComponent<ParticleSystemRenderer>();
        
        if (isApproachable)
        {
            haloParticleRenderer.material = Resources.Load("HoverHighlight_Yes") as Material;
        }
        else
        {
            haloParticleRenderer.material = Resources.Load("HoverHighlight_No") as Material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RunApproachableUpdate());
    }
}
