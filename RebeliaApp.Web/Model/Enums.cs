using System;
namespace RebeliaApp.Web.Model
{
    static public class Enums
    {
        public enum BattleResult {
            LOST = 0,
            DRAW = 1,
            WON = 2
        }

        public enum WinCondition {
            NONE = 0,
            SCENARIO = 1,
            CASTER_KILL = 2,
            DEATH_CLOCK = 3
        }

        public enum ResponseCode {
            SUCCESS,
            VALIDATION_ERROR,
            CONNECTION_ERROR
        }



    }
}
