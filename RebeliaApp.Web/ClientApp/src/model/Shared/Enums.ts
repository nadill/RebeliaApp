export enum ResponseCode {
  SUCCESS= 0,
  VALIDATION_ERROR= 1,
  CONNECTION_ERROR= 2
}

export enum BattleResult {
  LOST = 0,
  DRAW = 1,
  WON = 2
}

export enum WinCondition {
  NONE = 0,
  SCENARIO = 1,
  CASTER_KILL = 2,
  DEATH_CLOCK = 3
}