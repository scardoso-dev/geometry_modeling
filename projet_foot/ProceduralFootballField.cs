using UnityEngine;

public class ProceduralFootballField : MonoBehaviour
{
    public float fieldWidth = 50f;  // Largeur du terrain
    public float fieldLength = 100f; // Longueur du terrain
    public float lineWidth = 0.2f; // Largeur des lignes
    public Material grassMaterial; // Matériau pour le terrain

    void Start()
    {
        GenerateField();
    }

    void GenerateField()
    {
        // Créer le terrain principal
        GameObject field = GameObject.CreatePrimitive(PrimitiveType.Plane);
        field.transform.localScale = new Vector3(fieldLength / 10, 1, fieldWidth / 10);

        // Appliquer le matériau au terrain
        Renderer fieldRenderer = field.GetComponent<Renderer>();
        fieldRenderer.material = grassMaterial;
        
        // Générer les lignes de touche
        CreateLine(new Vector3(fieldLength / 2, 0.01f, 0), new Vector3(0, 0.01f, fieldWidth), Color.white);
        CreateLine(new Vector3(-fieldLength / 2, 0.01f, 0), new Vector3(0, 0.01f, fieldWidth), Color.white);

        // Générer les lignes de but
        CreateLine(new Vector3(0, 0.01f, fieldWidth / 2), new Vector3(fieldLength, 0.01f, 0), Color.white);
        CreateLine(new Vector3(0, 0.01f, -fieldWidth / 2), new Vector3(fieldLength, 0.01f, 0), Color.white);

        // Générer la ligne médiane
        CreateLine(new Vector3(0, 0.01f, 0), new Vector3(0, 0.01f, fieldWidth), Color.white);

        // Générer le cercle central
        CreateCircle(Vector3.zero, 9.15f, Color.white); // Rayon de 9.15m pour le cercle central
    }

    void CreateLine(Vector3 start, Vector3 size, Color color)
    {
        GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cube);
        line.transform.position = start;
        line.transform.localScale = new Vector3(size.x, lineWidth, size.z);
        line.GetComponent<Renderer>().material.color = color;
    }

    void CreateCircle(Vector3 center, float radius, Color color)
    {
        int segments = 100;
        LineRenderer lineRenderer = new GameObject("Circle").AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        float deltaTheta = (2f * Mathf.PI) / segments;
        float theta = 0f;

        for (int i = 0; i < segments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);
            Vector3 pos = new Vector3(x, 0.01f, z);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}
