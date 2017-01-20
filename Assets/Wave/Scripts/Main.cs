using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wave
{

    public enum GameStates
    {
        START = 1,
        GAME,
        END,
        CREDITS
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
        List<string> game_assets = new List<string> () { "Game" };
        List<string> end_assets = new List<string> () { "End" };
        List<string> credits_assets = new List<string> () { "Credits" };

        void Awake ()
        {
            AssetProvider = GetComponent<AssetProvider> ();

            states.Add (GameStates.START, new GameState (GameStates.START, "Start", start_assets));
            states.Add (GameStates.GAME, new GameState (GameStates.GAME, "Game", game_assets));
            states.Add (GameStates.END, new GameState (GameStates.END, "End", end_assets));
            states.Add (GameStates.CREDITS, new GameState (GameStates.CREDITS, "Credits", credits_assets));

            SwitchState (GameStates.START);
        }

        /**
         * unloads the current state assets, loads the new state assets
         * and make it the current state
         */
        void SwitchState (GameStates new_state)
        {
            if (current_state != null) {
                AssetProvider.UnloadAsset (current_state.Name);    
            }
                
            GameState state = states [new_state];

            foreach (var asset_id in state.Assets) {
                AssetProvider.LoadAssetAsync (asset_id);
            }
           
            current_state = state;
     
        }

        public void StartGame ()
        {
            SwitchState (GameStates.GAME);    
        }

        public void ShowCredits ()
        {
            SwitchState (GameStates.CREDITS);    
        }


    }

}

