using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }

    public void OnInteract()
    {
        PlayerCondition playerCondition = CharacterManager.Instance.Player.GetComponent<PlayerCondition>();
        
        if (data.type == ItemType.Consumable)
        {
            foreach (var consumable in data.consumables)
            {
                switch (consumable.type)
                {
                    case ConsumableType.Health:
                        playerCondition.Heal(consumable.value);
                        break;

                    case ConsumableType.Hunger:
                        break;

                }
            }
        }

        Destroy(gameObject);
    }
}