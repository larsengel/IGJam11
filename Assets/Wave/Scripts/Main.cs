using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wave
{
    using UnityEngine.SceneManagement;

    public enum GameStates
    {
        START = 1,
        LEVEL1,
        LEVEL2,
        END,
        CREDITS,

        LEVEL_WON,
        LEVEL_DEFEAT,
        GAME_FINISHED
    }

    public class GameState
    {
        public GameStates Id { get; private set; }

        public string Name { get; private set; }

        public List<string> Assets { get; private set; }

        public GameState (GameStates id, string name, List<string> assets)
        {
            Id = id;
            Name = name;
            Assets = assets;
        }
    }

    public class Main : MonoBehaviour
    {

        GameState current_state;

        AssetProvider AssetProvider;
       
        Dictionary<GameStates, GameState> states = new Dictionary<GameStates, GameState> ();

        // append the list of scenes you want to add to a gamestate at the end of this list
        // and add the scenes to the build_settings
        List<string> start_assets = new List<string> () { "Start" };
        List<string> level1_assets = new List<string> () { "Game", "Level1", "InGameUI" };
        List<string> level2_assets = new List<string> () { "Game", "Level2", "InGameUI" };
        List<string> end_assets = new List<string> () { "End" };
        List<string> credits_assets = new List<string>() { "Credits" };

        void Awake ()
        {
            AssetProvider = GetComponent<AssetProvider> ();

            states.Add (GameStates.START, new GameState (GameStates.START, "Start", start_assets));
            states.Add (GameStates.LEVEL1, new GameState (GameStates.LEVEL1, "Level1", level1_assets));
            states.Add (GameStates.LEVEL2, new GameState (GameStates.LEVEL2, "Level2", level2_assets));
            states.Add (GameStates.END, new GameState (GameStates.END, "End", end_assets));
            states.Add(GameStates.CREDITS, new GameState(GameStates.CREDITS, "Credits", credits_assets));
            this.states.Add(
                GameStates.LEVEL_WON,
                new GameState(GameStates.LEVEL_WON, "LevelWon", new List<string>() { "LevelWon" }));
            this.states.Add(
                GameStates.LEVEL_DEFEAT,
                new GameState(GameStates.LEVEL_DEFEAT, "LevelDefeat", new List<string>() { "LevelDefeat" }));
            this.states.Add(
                GameStates.GAME_FINISHED,
                new GameState(GameStates.GAME_FINISHED, "GameFinished", new List<string>() { "GameFinished" }));

            if (SceneManager.sceneCount <= 1)
            {
                SwitchState(GameStates.START);
            }
        }

        /**
         * unloads the current state assets, loads the new state assets
         * and make it the current state
         */

        public void SwitchState (GameStates new_state)
        {
            if (current_state != null) {

                foreach (var asset_id in current_state.Assets) {
                    AssetProvider.UnloadAsset (asset_id);    
                }
            }
                
            GameState state = states [new_state];

            foreach (var asset_id in state.Assets) {
                AssetProvider.LoadAssetAsync (asset_id);
            }
           
            current_state = state;
     
        }


        bool change;
        // Level switch for Debugging
        void Update ()
        {
            if (Input.GetKey (KeyCode.P) && !change) {
                change = true;
                if (current_state.Name == "Level1") {
                    SwitchState (GameStates.LEVEL2);
                } else {
                    SwitchState (GameStates.LEVEL1);
                }
            }

        }

        public void StartGame ()
        {
            SwitchState (GameStates.LEVEL1);    
        }

        public void ShowCredits ()
        {
            SwitchState (GameStates.CREDITS);    
        }


    }

}

