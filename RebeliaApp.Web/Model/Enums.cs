using System;
namespace RebeliaApp.Web.Model
{
    static public class Enums
    {
        public enum BATTLE_RESULT {
            LOST,
            DRAW,
            WIN
        }

        public enum DEFEATED_BY {
            CASTER_KILL,
            DEATH_CLOCK,
            OBJECTIVES,
            NONE
        }

        public enum USER_PERMISSION {
            GUEST,
            REGISTERED,
            MODERATOR,
            ADMIN
        }

        public enum USER_STATUS {
            UNAUTHORIZED,
            AUTHORIZED
        }

        public enum RESPONSE_CODE {
            SUCCESS,
            VALIDATION_ERROR,
            CONNECTION_ERROR
        }



    }
}
