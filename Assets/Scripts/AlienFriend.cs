using UnityEngine;
public class AlienFriend: MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float followDistance = 2f;

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;

        if (direction.magnitude > followDistance)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
