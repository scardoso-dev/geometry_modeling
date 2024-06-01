using UnityEngine;

public class Player : MonoBehaviour
{
    public float fieldWidth = 80;  // Largeur du terrain
    public float fieldLength = 40; // Longueur du terrain
    public int numberOfPlayers = 11; // Nombre de joueurs par équipe

    void Start()
    {
        GenerateTeam(new Vector3(-fieldLength / 4, 0, 0), Color.red); // Génère l'équipe rouge
        GenerateTeam(new Vector3(fieldLength / 4, 0, 0), Color.blue); // Génère l'équipe bleue
    }

    void GenerateTeam(Vector3 startingPosition, Color teamColor)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            // Créer un joueur en instanciant une primitive pour représenter la forme humanoïde
            GameObject player = new GameObject("Player");
            
            // Création des parties du corps en utilisant des cubes (torse, jambes, bras)
            GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cube);
            body.transform.parent = player.transform;
            body.transform.localScale = new Vector3(1, 2, 0.5f); // Taille du torse
            body.transform.localPosition = new Vector3(0, 1, 0); // Position du torse
            
            GameObject leg1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leg1.transform.parent = player.transform;
            leg1.transform.localScale = new Vector3(0.5f, 2, 0.5f); // Taille de la jambe
            leg1.transform.localPosition = new Vector3(-0.25f, 1, 0); // Position de la jambe gauche
            
            GameObject leg2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leg2.transform.parent = player.transform;
            leg2.transform.localScale = new Vector3(0.5f, 2, 0.5f); // Taille de la jambe
            leg2.transform.localPosition = new Vector3(0.25f, 1, 0); // Position de la jambe droite
            
            GameObject arm1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            arm1.transform.parent = player.transform;
            arm1.transform.localScale = new Vector3(0.5f, 1, 0.5f); // Taille du bras
            arm1.transform.localPosition = new Vector3(-0.75f, 1.5f, 0); // Position du bras gauche
            
            GameObject arm2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
            arm2.transform.parent = player.transform;
            arm2.transform.localScale = new Vector3(0.5f, 1, 0.5f); // Taille du bras
            arm2.transform.localPosition = new Vector3(0.75f, 1.5f, 0); // Position du bras droit
            
            // Création de la tête au-dessus du torse
            GameObject head = GameObject.CreatePrimitive(PrimitiveType.Cube);
            head.transform.parent = player.transform;
            head.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f); // Taille de la tête
            head.transform.localPosition = new Vector3(0, 2.4f, 0); // Position de la tête
            
            // Appliquer la couleur de l'équipe à chaque partie du corps
            Renderer[] renderers = player.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.material.color = teamColor;
            }

            // Donner une rotation aléatoire uniquement sur l'axe Y
            float randomRotationY = Random.Range(0f, 360f);
            player.transform.rotation = Quaternion.Euler(0f, randomRotationY, 0f);

            // Positionner le joueur sur le terrain de manière aléatoire
            player.transform.position = startingPosition + GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        // Génère une position aléatoire sur le terrain pour un joueur
        float x = Random.Range(-fieldWidth / 2, fieldWidth / 2);
        float z = Random.Range(-fieldLength / 2, fieldLength / 2);
        return new Vector3(x, 0, z);
    }
}
