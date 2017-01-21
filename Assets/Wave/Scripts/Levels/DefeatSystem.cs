namespace Wave.Levels
{
    using UnityEngine;

    public class DefeatSystem : MonoBehaviour
    {
        public string LevelDefeatScene = "LevelDefeat";

        public LevelSystem LevelSystem;

        [ContextMenu("Loose Level")]
        private void LooseLevel()
        {
            Main.Instance.SwitchState(GameStates.LEVEL_DEFEAT);
        }

        private void Reset()
        {
            if (this.LevelSystem == null)
            {
                this.LevelSystem = FindObjectOfType<LevelSystem>();
            }
        }
    }
}