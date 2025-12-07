using UnityEngine;
using UnityEngine.UI;

public class SlidersScript : MonoBehaviour
{
    [Header("References")]
    public Renderer blackHoleRenderer;
    public Slider accretionRateSlider;
    public Slider diskVelocitySlider;
    public Slider temperatureSlider;
    public Slider shearIntensitySlider;
    private Material blackHoleMat;

    void Start()
    {
        blackHoleMat = blackHoleRenderer.material; // Making sure we’re editing a unique instance of the material

        // --- Accretion Rate ---
        accretionRateSlider.onValueChanged.AddListener(SetAccretionRate); // Hook slider to function
        accretionRateSlider.value = 0.5f; // Set default value as 0.5
        SetAccretionRate(accretionRateSlider.value); // Initialize shader with current slider value

        // --- Disk Rotation Speed ---
        diskVelocitySlider.onValueChanged.AddListener(SetDiskVelocity); // Hook slider to function
        diskVelocitySlider.minValue = 0f; // Set minimum value
        diskVelocitySlider.maxValue = 4f; // Set maximum value
        diskVelocitySlider.value = 2f; // Set default value as 2
        SetDiskVelocity(diskVelocitySlider.value); // Initialize shader with current slider value

        // --- Temperature ---
        temperatureSlider.onValueChanged.AddListener(SetTemperature); // connect event
        temperatureSlider.minValue = 0f;
        temperatureSlider.maxValue = 1f;
        temperatureSlider.value = 0.5f; // white by default
        SetTemperature(temperatureSlider.value); // initialize

        // --- Shear Intensity ---
        shearIntensitySlider.onValueChanged.AddListener(SetShearIntensity);
        shearIntensitySlider.minValue = 0f;
        shearIntensitySlider.maxValue = 0.9f;
        shearIntensitySlider.value = 0.45f;
        SetShearIntensity(shearIntensitySlider.value);

    }

    void SetAccretionRate(float value)
    {
        blackHoleMat.SetFloat("_DiscOuterRadius", value);
    }

    void SetDiskVelocity(float value)
    {
        blackHoleMat.SetFloat("_DiscSpeed", value);
    }

    void SetTemperature(float value)
    {
        blackHoleMat.SetFloat("_Temperature", value);
    }

    void SetShearIntensity(float value)
    {
        blackHoleMat.SetFloat("_HueRadius", value);
    }

}

