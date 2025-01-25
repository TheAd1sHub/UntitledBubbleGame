using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Transform bubble; // Assign the object you want to scale
    public Slider sizeSlider;
    public GameObject bubbleMesh;
    public GameObject bubbleMeshPrefab;
    public ParticleSystem bubbleParticles;

    private float previousSliderValue;
    private Vector3 initialScale; // Store the object's original scale

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (bubble != null)
        {
            previousSliderValue = sizeSlider.value;
            initialScale = bubble.localScale; // Save the original scale
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

            if (value > 9f && bubbleMesh != null)
            {
                Destroy(bubbleMesh);
                sizeSlider.value = 0;

                Vector3 newPosition = new Vector3(-0.041841507f, 1.29499996f, -0.0457854271f); // Specify the position
                bubbleMesh = Instantiate(bubbleMeshPrefab, newPosition, Quaternion.identity);
                bubbleMesh.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

                bubble = bubbleMesh.transform;

                bubbleParticles.Play();
            }

            // Update the previous slider value
            previousSliderValue = value;
        }
    }



}
