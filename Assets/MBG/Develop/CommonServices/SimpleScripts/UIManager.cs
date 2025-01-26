using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using TMPro;
using System.Collections.Generic;



public class UIManager : MonoBehaviour
{
    public AudioSource effectsSource;

    public Transform bubble; // Assign the object you want to scale
    public Slider sizeSlider;
    [Header("Bubble")]
    public GameObject bubbleMesh;
    public GameObject bubbleMeshPrefab;
    [Header("FX")]
    public ParticleSystem bubbleParticles;
    public AudioClip bubbleSound;
    public TMP_Text recipeText;
    public int ingidientsCount;

    [Header("craftBtn")]
    public GameObject infoPanel;
    public GameObject craftBtn;
    public ingridType ingridTypeSave;

    public TMP_Text mixerText;

    [Header("sliders")]
    public Slider durSlider;
    public Slider respSlider;

    public List<Material> materialsBubble = new List<Material>(); // Empty list
    public Material currentMat;

    private float previousSliderValue;
    private Vector3 initialScale; // Store the object's original scale

    public float blinkInterval = 2.0f; // Time interval between blinks

    private Coroutine blinkCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bubble != null)
        {
            previousSliderValue = sizeSlider.value;
            initialScale = bubble.localScale; // Save the original scale
        }

        recipeText.text = "";
        ingidientsCount = 0;
        ingridTypeSave = ingridType.Undefined;

        mixerText.text = "Start crafting. Clik on any ingridient";
        StartBlinking();

        durSlider.value = 0;
        respSlider.value = 0;
        bubbleMesh.SetActive(false);

        //set def mat
        currentMat = materialsBubble[0];
    }

    private void Update()
    {
        Button craftButton= craftBtn.GetComponent<Button>();

        if (recipeText.text == "")
        {
            craftButton.interactable = false;
        }
        else if (ingidientsCount ==2 && recipeText.text != "")
        {
            craftButton.interactable = true;
        }
    }

    public void AssingnMat(int number)
    {
        MeshRenderer meshRenderer = bubbleMesh.GetComponent<MeshRenderer>();
        MeshRenderer meshRenderer2 = bubbleMeshPrefab.GetComponent<MeshRenderer>();

        // Check if the MeshRenderer exists
        if (meshRenderer != null)
        {
            // Assign the material
            meshRenderer.material = materialsBubble[number];
            Debug.Log("Material assigned to 1.");
        }

        if (meshRenderer2 != null)
        {
            // Assign the material
            meshRenderer2.material = materialsBubble[number];
            Debug.Log("Material assigned to 2.");
        }
    }


    public void OnSliderValueChanged()
    {

        float value = sizeSlider.value;

        if (bubble != null)
        {
            // Calculate the scale based on slider value. The scale will range from 0.1 to 2.5
            float scale = Mathf.Lerp(0.1f, 2.5f, value / 9f);

            // Set the new scale on the bubble
            bubble.localScale = new Vector3(scale, scale, scale);

            if (value == 10f && bubbleMesh != null)
            {
                Destroy(bubbleMesh);
                sizeSlider.value = 0;

                Vector3 newPosition = new Vector3(-0.041841507f, 1.29499996f, -0.0457854271f); // Specify the position
                
                bubbleMesh = Instantiate(bubbleMeshPrefab, newPosition, Quaternion.identity);
                bubbleMesh.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                bubble = bubbleMesh.transform;

                //effects
                bubbleParticles.Play();
                effectsSource.PlayOneShot(bubbleSound);
            }
            
            // Update the previous slider value
            previousSliderValue = value;
        }
    }

    public void CleanText()
    {
        StopBlinking();
        bubbleMesh.SetActive(true);
        bubbleMeshPrefab.SetActive(true);
        mixerText.text = "It's " + recipeText.text + ". Try inflate it!";
        recipeText.text = "";
        ingidientsCount = 0;
        ingridTypeSave = ingridType.Undefined;
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            mixerText.enabled = !mixerText.enabled; // Toggle visibility
            yield return new WaitForSeconds(blinkInterval); // Wait for the blink interval
        }
    }

    public void StartBlinking()
    {
        // Start the coroutine if it's not already running
        if (blinkCoroutine == null)
        {
            blinkCoroutine = StartCoroutine(BlinkText());
        }
    }

    public void StopBlinking()
    {
        // Stop the coroutine if it's running
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
            mixerText.enabled = true; // Ensure the text is visible after stopping
        }
    }

}
