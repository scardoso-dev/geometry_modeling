using UnityEngine;

public class GenerateSimpleGoals : MonoBehaviour
{
    public float fieldWidth = 50f;  // Largeur du terrain
    public float fieldLength = 100f; // Longueur du terrain
    public float goalWidth = 7.32f; // Largeur des buts (7.32m)
    public float goalHeight = 2.44f; // Hauteur des buts (2.44m)
    public float goalDepth = 2.0f; // Profondeur des buts

    void Start()
    {
        GenerateGoalsAtBothEnds();
    }

    void GenerateGoalsAtBothEnds()
    {
        // Générer les cages de but aux deux extrémités du terrain
        CreateGoal(new Vector3(-fieldLength / 2 - goalDepth / 2, goalHeight / 2, 0));
        CreateGoal(new Vector3(fieldLength / 2 + goalDepth / 2, goalHeight / 2, 0));
    }

    void CreateGoal(Vector3 position)
    {
        // Créer le rectangle du but
        GameObject goal = GameObject.CreatePrimitive(PrimitiveType.Cube);
        goal.transform.localScale = new Vector3(goalDepth, goalHeight, goalWidth);
        goal.transform.position = position;
        goal.GetComponent<Renderer>().material.color = Color.white;
    }
}