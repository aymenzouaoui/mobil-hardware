using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    public float earthOrbitSpeed = 10f;   // Vitesse de rotation de la Terre autour du Soleil
    public float earthRotationSpeed = 30f;  // Vitesse de rotation de la Terre sur elle-même
    public float moonOrbitSpeed = 50f;    // Vitesse de rotation de la Lune autour de la Terre
    public float moonDistanceFromEarth = 2f;  // Distance de la Lune par rapport à la Terre

    private Vector3 moonInitialPosition;

    void Start()
    {
        // Sauvegarder la position initiale de la Lune par rapport à la Terre
        moonInitialPosition = transform.GetChild(0).GetChild(0).localPosition;
    }

    // Update est appelé à chaque frame
    void Update()
    {
        // Rotation de la Terre autour du Soleil
        Transform earth = transform.GetChild(0);

        // Rotation de la Terre autour du Soleil (utilisation de Rotate pour simuler l'orbite)
        earth.Rotate(Vector3.up, earthOrbitSpeed * Time.deltaTime, Space.World);

        // Rotation de la Terre sur elle-même
        earth.Rotate(Vector3.up * earthRotationSpeed * Time.deltaTime);

        // Rotation de la Lune autour de la Terre
        Transform moon = earth.GetChild(0); // Récupère la Lune

        // Rotation de la Lune sur elle-même (si souhaité)
        moon.Rotate(Vector3.up * moonOrbitSpeed * Time.deltaTime);

        // Ajuster la position de la Lune pour qu'elle orbite autour de la Terre en utilisant Rotate
        moon.Rotate(Vector3.up, moonOrbitSpeed * Time.deltaTime, Space.Self);

        // Ajuster la position de la Lune pour qu'elle reste à une distance fixe de la Terre
        moon.localPosition = moonInitialPosition.normalized * moonDistanceFromEarth;
    }
}
