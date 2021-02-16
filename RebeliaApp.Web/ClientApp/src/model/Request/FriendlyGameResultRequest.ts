import { PlayerGameScore } from '../Shared/PlayerGameScore';
import { BattleResult } from '../Shared/Enums';


export class FriendlyGameResultRequest {
  date: Date;
  playerList: PlayerGameScore[];
  winnerID: number | null;
  pointFormat: number;
  rounds: number;
  systemID: number;
  scenarioID: number;

}
