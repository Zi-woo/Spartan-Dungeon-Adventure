using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour, IInteractable
{
    public ItemData data;               
    [SerializeField] private float jumpForce = 15f;  

    public string GetInteractPrompt()
    {
        return $"{data.displayName}\n{data.description}";
    }

    public void OnInteract()
    {
        Rigidbody rb = CharacterManager.Instance.Player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 대상이 Player고, 위에서 밟은 경우에만 실행
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.transform.position.y > transform.position.y + 0.5f)
            {
                OnInteract();  // 점프 효과 발동
            }
        }
    }
}