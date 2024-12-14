using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour
{
    public Transform Point;

    [Header("Player")]
    public GameObject Player;

    [Header("Tags")]
    public string Tag;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            Player.GetComponent<Rigidbody>().isKinematic = true;
            Player.GetComponent<Rigidbody>().useGravity = false;
            StartCoroutine(TeleportPlayer());
        }
    }

    IEnumerator TeleportPlayer()
    {
        Collider[] colliders = Object.FindObjectsByType<Collider>(FindObjectsSortMode.None);
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        Player.transform.position = Point.position;

        yield return new WaitForSeconds(1);

        Player.GetComponent<Rigidbody>().isKinematic = false;
        Player.GetComponent<Rigidbody>().useGravity = true;
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
