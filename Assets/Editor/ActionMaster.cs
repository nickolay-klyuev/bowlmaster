using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    public enum Action { Tidy, Reset, EndTurn, EndGame };

    public Action Bowl(int pins)
    {
        if (pins < 0 || pins > 10)
        {
            throw new UnityException("Invalid numbers of pins");
        }

        if (pins == 10)
        {
            return Action.EndTurn;
        }

        throw new UnityException("Can not return any of actions");
    }
}
