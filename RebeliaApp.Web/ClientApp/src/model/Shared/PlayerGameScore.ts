import { WinCondition, BattleResult} from "./Enums";

export class PlayerGameScore {
  playerID: number;
  armyID: number;
  themeID: number | null;
  casterID: number | null;
  winCondition: WinCondition;
  battleResult: BattleResult;
  objectivePoints: number;
  armyPoints: number;
}
