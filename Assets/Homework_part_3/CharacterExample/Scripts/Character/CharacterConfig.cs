using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu( menuName = "Configs/CharacterConfig", fileName = "CharacterConfig" )]
public class CharacterConfig : ScriptableObject {

    [Range( 0, 10 )] public float DefaultStamina;
    [field: SerializeField][Range(3,10)] public float StaminaFullRecoverySec;
    [field: SerializeField] public RunningStateConfig RunningStateConfig { get; private set; }
    [field: SerializeField] public FastRunningStateConfig FastRunningStateConfig { get; private set; }
    [field: SerializeField] public SlowRunningStateConfig SlowRunningStateConfig { get; private set; }
    [field: SerializeField] public AirbornStateConfig AirbornStateConfig { get; private set; }

}
