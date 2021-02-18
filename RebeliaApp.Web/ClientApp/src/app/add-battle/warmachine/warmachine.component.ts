import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Army, Theme, PlayerGameScore, Scenario, MapFormat, Caster } from '../../../model/Shared';
import { FriendlyGameResultRequest } from '../../../model/Request/FriendlyGameResultRequest';
import { FriendlyGameResultResponse } from '../../../model/Response/FriendlyGameResultResponse';

import { WarmachineService } from '../../../providers/warmachine.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AccountService } from '../../../providers/account.service';
import { UserAccount } from '../../../model/Shared/UserAccount';

import { concat } from 'rxjs';
import { BattleResult, WinCondition, ResponseCode } from '../../../model/Shared/Enums';
import { Router } from '@angular/router';

@Component({
  selector: 'add-warmachine-component',
  templateUrl: './warmachine.component.html'
})

export class AddWarmachineComponent implements OnInit {

  dataModel: {
    armies: Army[],
    themes: Theme[],
    casters: Caster[],
    scenarios: Scenario[],
    players: UserAccount[]
  } = {
      armies: [],
      themes: [],
      casters: [],
      scenarios: [],
      players: []
    }

  requestModel: FriendlyGameResultRequest = {
    date: new Date(),
    playerList: [{
      armyID: 0,
      armyPoints: 0,
      objectivePoints: 0,
      themeID: 0,
      casterID: 0,
      playerID: 0,
      battleResult: BattleResult.DRAW,
      winCondition: WinCondition.NONE
    }, {
      armyID: 0,
      armyPoints: 0,
      objectivePoints: 0,
      themeID: 0,
      casterID: 0,
      playerID: 0,
      battleResult: BattleResult.DRAW,
      winCondition: WinCondition.NONE
    }],
    pointFormat: 75,
    rounds: 5,
    scenarioID: 0,
    systemID: 2,
    winnerID: null
  }

  formModel: {
    scenarioImgUrl: string,
    validation: {
      scenarioValid: boolean,
      opponentValid: boolean,
      armyValid: boolean,
      casterValid: boolean,
    },
    loggedUserName: string,
    armyPool: {
      player1: Army[],
      player2: Army[]
    },
    availableThemes: {
      player1: Theme[],
      player2: Theme[]
    },
    availableCasters: {
      player1: Caster[],
      player2: Caster[]
    },
    armyImg: {
      player1: string,
      player2: string
    },
    casterImg: {
      player1: string,
      player2: string
    },
    inputFieldValid: {
      roundInput: boolean,
      objectiveInputP1: boolean,
      armyInputP1: boolean,
      objectiveInputP2: boolean,
      armyInputP2: boolean
    }
  } = {
      scenarioImgUrl: '',
      validation: {
        scenarioValid: false,
        opponentValid: false,
        armyValid: false,
        casterValid: false,
      },
      loggedUserName: '',
      armyPool: {
        player1: [],
        player2: []
      },
      availableThemes: {
        player1: [],
        player2: []
      },
      availableCasters: {
        player1: [],
        player2: []
      },
      armyImg: {
        player1: '',
        player2: ''
      },
      casterImg: {
        player1: '',
        player2: ''
      },
      inputFieldValid: {
        roundInput: true,
        objectiveInputP1: true,
        armyInputP1: true,
        objectiveInputP2: true,
        armyInputP2: false
      }

    }

  spinnerModel = {
    armiesLoaded: false,
    scenariosLoaded: false,
    playersLoaded: false,
    submitLoaded: true
  }

  public battleResult: FriendlyGameResultRequest;


  constructor(private warmachineService: WarmachineService, private accountService: AccountService, private router: Router) {
  }

  ngOnInit() {
    // Load Armies, Casters and Themes to models /
    this.warmachineService.GetWarmachineArmies().subscribe(result => {
      this.dataModel.armies = this.dataModel.armies.concat(result).sort((a, b) => {
        return a.armyName > b.armyName ? 1 : a.armyName < b.armyName ? -1 : 0;
      });

      this.dataModel.armies.forEach(army => {
        this.dataModel.themes = this.dataModel.themes.concat(army.armyThemes);
        this.dataModel.casters = this.dataModel.casters.concat(army.casterList);
      });

      this.formModel.armyPool.player1 = this.formModel.armyPool.player1.concat(this.dataModel.armies);
      this.formModel.armyPool.player2 = this.formModel.armyPool.player2.concat(this.dataModel.armies);

      this.formModel.availableThemes.player1 = this.formModel.availableThemes.player1.concat(this.dataModel.themes);
      this.formModel.availableThemes.player2 = this.formModel.availableThemes.player2.concat(this.dataModel.themes);

      this.formModel.availableCasters.player1 = this.formModel.availableCasters.player1.concat(this.dataModel.casters);
      this.formModel.availableCasters.player2 = this.formModel.availableCasters.player2.concat(this.dataModel.casters);

      this.formModel.casterImg.player1 = "none";
      this.formModel.casterImg.player2 = "none";

      this.ArmyChanged(0, "player1", 0);
      this.ArmyChanged(0, "player2", 1);

      this.CasterChanged(0, "player1", 0);
      this.CasterChanged(0, "player2", 1);


      this.spinnerModel.armiesLoaded = true;
    });

    // Load Scenarios to models/
    this.warmachineService.GetWarmachineScenarios().subscribe(result => {
      this.dataModel.scenarios = this.dataModel.scenarios.concat(result);
      this.spinnerModel.scenariosLoaded = true;
    }, error => console.error(error));

    // Load Users to models
    this.accountService.GetAllAccountsExceptLoggedUser().subscribe(users => {
      this.dataModel.players = this.dataModel.players.concat(users.accountList);
      this.dataModel.players.forEach(player => {
        player.fullName = player.nick !== null ?
          player.firstName + ' "' + player.nick + '" ' + player.lastName :
          player.firstName + ' ' + player.lastName;
      });
      this.spinnerModel.playersLoaded = true;
    });

    // Load logged user data/
    let user = this.accountService.GetUserTokenInfo();
    this.formModel.loggedUserName = user.fullName;
    this.requestModel.playerList[0].playerID = Number(user.playerID);

  }

  private ArmyChanged(selectedID: number, player: string, num: number): void {
    this.formModel.casterImg[player] = 'none';
    this.formModel.availableThemes[player] = this.dataModel.themes.filter(x => x.armyID == selectedID).sort((a, b) => {
      return a.themeName > b.themeName ? 1 : a.themeName < b.themeName ? -1 : 0;
    });
    this.formModel.availableCasters[player] = this.dataModel.casters.filter(x => x.armyID == selectedID);
    this.CasterChanged(0, player, num);
    this.formModel.armyImg[player] = (selectedID == 0) ? 'url(/assets/warmachine-icons/warmachine-logo.png)' :
      "url(/assets/warmachine-icons/" + this.dataModel.armies.find(a => a.armyID == selectedID).armyImage + ".png)";
    this.requestModel.playerList[num].armyID = Number(selectedID);
    this.formModel.validation.armyValid = this.requestModel.playerList[0].armyID != 0 && this.requestModel.playerList[1].armyID != 0 ? true : false;
  }

  private CasterChanged(selectedID: number, player: string, num: number) {
    this.formModel.casterImg[player] = (selectedID == 0) ? 'url(/assets/warmachine-icons/caster-placeholder.jpeg)' :
      "url(/assets/warmachine-icons/casters/" + this.dataModel.casters.find(t => t.casterID == selectedID).casterImg + ".png)";
    this.requestModel.playerList[num].casterID = Number(selectedID);
    this.formModel.validation.casterValid = (this.requestModel.playerList[0].casterID != 0 && this.requestModel.playerList[1].casterID != 0) ? true : false;
  }

  CheckboxUpdated(playerNum: number, winCon: number) {
    if (this.requestModel.playerList[playerNum].winCondition == winCon) {
      this.requestModel.playerList[0].winCondition = WinCondition.NONE;
      this.requestModel.playerList[1].winCondition = WinCondition.NONE;
    } else {
      this.requestModel.playerList[0].winCondition = WinCondition.NONE;
      this.requestModel.playerList[1].winCondition = WinCondition.NONE;

      this.requestModel.playerList[playerNum].winCondition = winCon;
    }

  }

  private UpdateScenario(scenarioId: number) {
    if (Number(scenarioId) != 0) {
      this.requestModel.scenarioID = Number(scenarioId);
      let scenario: Scenario[] = this.dataModel.scenarios.filter(x => x.scenarioID == scenarioId);
      let baseUrl = "/assets/warmachine-scenarios/";
      let imgUrl: string;
      this.requestModel.pointFormat = Number(this.requestModel.pointFormat);
      
      imgUrl = scenario[0].scenarioFormats[0].standardFormat;
       
      this.formModel.scenarioImgUrl = baseUrl + imgUrl + '.png';
    }
    this.formModel.validation.scenarioValid = (Number(scenarioId) !== 0) ? true : false;
  }

  private ThemeChanged(selectedID: number, playerIndex: number): void {
    this.requestModel.playerList[playerIndex].themeID = Number(selectedID);
  }

  private OpponentChanged(selectedID: number): void {
    this.requestModel.playerList[1].playerID = Number(selectedID);
    this.formModel.validation.opponentValid = (Number(selectedID) != 0) ? true : false;
  }

  private IsFormValid(): boolean {
    return this.formModel.validation.scenarioValid && this.formModel.validation.opponentValid && this.formModel.validation.casterValid && this.formModel.validation.armyValid;
  }

  private SubmitResult() {
    if (this.requestModel.playerList[0].winCondition == WinCondition.CASTER_KILL ||
      this.requestModel.playerList[0].winCondition == WinCondition.DEATH_CLOCK) {
        //Player1 wins by casterkill/deathclock
      this.requestModel.winnerID = this.requestModel.playerList[0].playerID;

      this.requestModel.playerList[1].winCondition = WinCondition.NONE;
      this.requestModel.playerList[0].battleResult = BattleResult.WON;
      this.requestModel.playerList[1].battleResult = BattleResult.LOST;

    } else if (this.requestModel.playerList[1].winCondition == WinCondition.CASTER_KILL ||
      this.requestModel.playerList[1].winCondition == WinCondition.DEATH_CLOCK) {
        //Player2 wins by casterkill/deathclock
      this.requestModel.winnerID = this.requestModel.playerList[1].playerID;

      this.requestModel.playerList[0].winCondition = WinCondition.NONE;
      this.requestModel.playerList[1].battleResult = BattleResult.WON;
      this.requestModel.playerList[0].battleResult = BattleResult.LOST;
    }else  if(this.requestModel.playerList[0].objectivePoints > this.requestModel.playerList[1].objectivePoints) {
      //Player1 wins by scenario
      this.requestModel.winnerID = this.requestModel.playerList[0].playerID;
      this.requestModel.playerList[0].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[1].winCondition = WinCondition.NONE;
      this.requestModel.playerList[0].battleResult = BattleResult.WON;
      this.requestModel.playerList[1].battleResult = BattleResult.LOST;

    } else if (this.requestModel.playerList[0].objectivePoints < this.requestModel.playerList[1].objectivePoints) {
      // Player2 wins by scenario
      this.requestModel.winnerID = this.requestModel.playerList[1].playerID;
      this.requestModel.playerList[1].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[0].winCondition = WinCondition.NONE;
      this.requestModel.playerList[1].battleResult = BattleResult.WON;
      this.requestModel.playerList[0].battleResult = BattleResult.LOST;

    } else if (this.requestModel.playerList[0].armyPoints > this.requestModel.playerList[1].armyPoints) {
      //Player1 wins by scenario
      this.requestModel.winnerID = this.requestModel.playerList[0].playerID;
      this.requestModel.playerList[0].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[1].winCondition = WinCondition.NONE;
      this.requestModel.playerList[0].battleResult = BattleResult.WON;
      this.requestModel.playerList[1].battleResult = BattleResult.LOST;

    } else if (this.requestModel.playerList[0].armyPoints < this.requestModel.playerList[1].armyPoints) {
      // Player2 wins by scenario 
      this.requestModel.winnerID = this.requestModel.playerList[1].playerID;
      this.requestModel.playerList[1].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[0].winCondition = WinCondition.NONE;
      this.requestModel.playerList[1].battleResult = BattleResult.WON;
      this.requestModel.playerList[0].battleResult = BattleResult.LOST;
    }


    this.spinnerModel.submitLoaded = false;
    this.warmachineService.SubmitFriendlyGameResult(this.requestModel).subscribe(result => {
      if (result.responseCode == ResponseCode.SUCCESS) {
        this.router.navigateByUrl("/");
      } else {
        console.log(result.responseMessage);
      }
      this.spinnerModel.submitLoaded = true;
    });


  }


}