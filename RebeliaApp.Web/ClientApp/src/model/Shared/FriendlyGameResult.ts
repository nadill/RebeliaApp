import { PlayerGameScore } from './PlayerGameScore';

export class FriendlyGameResult {
  date: number;
  player1Result: PlayerGameScore | null;
  player2Result: PlayerGameScore | null;
  winnerID: number;
  pointFormat: number = 0;
  rounds: number = 0;
  gameSystemID: number = 0;
  scenarioID: number = 0;

}
