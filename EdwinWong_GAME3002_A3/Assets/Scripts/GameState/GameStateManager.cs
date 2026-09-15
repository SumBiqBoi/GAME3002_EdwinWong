using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class GameStateManager
{
    static Stack<AbstractGameState> gameStateStack;

    static public TitleState  titleState;
    static public MenuState   menuState;
    static public ShopState   shopState;
    static public GameState   gameState;
    static public OptionState optionState;

    static public void Initialize(BootStrapper bootStrapper)
    {
        gameStateStack = new Stack<AbstractGameState>();

        titleState = new TitleState(bootStrapper.titleScreen);
        menuState = new MenuState(bootStrapper.menuScreen);
        shopState = new ShopState(bootStrapper.shopScreen);
        gameState = new GameState(bootStrapper.gameScreen);
        optionState = new OptionState(bootStrapper.optionScreen);

        PushGameStateOnStack(titleState);
    }

    static public void Update()
    {
        gameStateStack.Peek().Update();
    }

    static public void PushGameStateOnStack(AbstractGameState gameState)
    {
        if (gameStateStack.Count > 0)
        {
            gameStateStack.Peek().Pause();
        }

        gameStateStack.Push(gameState);
        gameState.LoadGameState();
    }

    static public void PopGameStateOffStack()
    {
        if (gameStateStack.Peek() != titleState)
        {
            gameStateStack.Peek().UnloadGameState();
            gameStateStack.Pop();
            gameStateStack.Peek().Resume();
        }
    }

    static public void PopGameUntilStateIs(AbstractGameState gameState)
    {
        while (gameStateStack.Peek() != gameState)
        {
            PopGameStateOffStack();
        }
    }
}
