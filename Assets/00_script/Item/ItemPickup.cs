using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private string itemName = "Potion";
    [SerializeField] private float pickupRange = 1.5f;

    private Transform player;
    private InventoryManager inventory;

    private void Start()
    {
        Debug.Log("[ItemPickup] 아이템 생성됨");

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null)
        {
            Debug.LogError("[ItemPickup] Player 태그를 찾지 못함");
            return;
        }

        player = playerObject.transform;
        inventory = playerObject.GetComponent<InventoryManager>();

        if (inventory == null)
        {
            Debug.LogError("[ItemPickup] InventoryManager 없음");
            return;
        }

        Debug.Log("[ItemPickup] 초기화 성공");
    }

    private void Update()
    {
        if (player == null || inventory == null)
            return;

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log($"[ItemPickup] F 입력, 거리: {distance}");

            if (distance <= pickupRange)
            {
                Pickup();
            }
            else
            {
                Debug.Log("[ItemPickup] 아이템이 너무 멀리 있음");
            }
        }
    }

    private void Pickup()
    {
        inventory.AddItem(itemName);
        Debug.Log("[ItemPickup] 획득 성공");

        Destroy(gameObject);
    }
}