import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Army, Theme, PlayerGameScore, Scenario, MapFormat } from '../../../model/Shared';
import { FriendlyGameResultRequest } from '../../../model/Request/FriendlyGameResultRequest';
import { FriendlyGameResultResponse } from '../../../model/Response/FriendlyGameResultResponse';

import { InfinityService } from '../../../providers/infinity.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AccountService } from '../../../providers/account.service';
import { UserAccount } from '../../../model/Shared/UserAccount';

import { concat } from 'rxjs';
import { BattleResult, WinCondition, ResponseCode } from '../../../model/Shared/Enums';
import { Router } from '@angular/router';

@Component({
  selector: 'add-infinity-component',
  templateUrl: './infinity.component.html'
})

export class AddInfinityComponent implements OnInit {

  dataModel: {
    armies: Army[],
    themes: Theme[],
    scenarios: Scenario[],
    players: UserAccount[]
  } = {
      armies: [],
      themes: [],
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
      casterID: null,
      playerID: 0,
      battleResult: BattleResult.DRAW,
      winCondition: WinCondition.NONE
    }, {
      armyID: 0,
      armyPoints: 0,
      objectivePoints: 0,
      themeID: 0,
      casterID: null,
      playerID: 0,
      battleResult: BattleResult.DRAW,
      winCondition: WinCondition.NONE
      }],
    pointFormat: 150,
    rounds: 3,
    scenarioID: 0,
    systemID: 1,
    winnerID: null
  }

  formModel: {
    scenarioImgUrl: string,
    validation: {
      scenarioValid: boolean,
      opponentValid: boolean
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
    armyImg: {
      player1: string,
      player2: string
    },
    themeImg: {
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
        opponentValid: false
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
      armyImg: {
        player1: '',
        player2: ''
      },
      themeImg: {
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


  constructor(private infinityService: InfinityService, private accountService: AccountService, private router: Router) {
  }

  ngOnInit() {
    // Load Armies and Themes to models 
    this.infinityService.GetInfinityArmies().subscribe(result => {
      this.dataModel.armies = this.dataModel.armies.concat(result);

      this.dataModel.armies.forEach(army => {
        this.dataModel.themes = this.dataModel.themes.concat(army.armyThemes);
      });

      this.formModel.armyPool.player1 = this.formModel.armyPool.player1.concat(this.dataModel.armies);
      this.formModel.armyPool.player2 = this.formModel.armyPool.player2.concat(this.dataModel.armies);

      this.formModel.availableThemes.player1 = this.formModel.availableThemes.player1.concat(this.dataModel.themes);
      this.formModel.availableThemes.player2 = this.formModel.availableThemes.player2.concat(this.dataModel.themes);

      this.formModel.armyImg.player1 = "url(/assets/infinity-icons/" + this.dataModel.armies[0].armyImage + ".svg)";
      this.formModel.armyImg.player2 = "url(/assets/infinity-icons/" + this.dataModel.armies[0].armyImage + ".svg)";

      this.formModel.themeImg.player1 = "none";
      this.formModel.themeImg.player2 = "none";

      this.ArmyChanged(this.dataModel.armies[0].armyID, "player1", 0);
      this.ArmyChanged(this.dataModel.armies[0].armyID, "player2", 1);

      this.spinnerModel.armiesLoaded = true;
    });

    // Load Scenarios to models/
    this.infinityService.GetInfinityScenarios().subscribe(result => {
      this.dataModel.scenarios = this.dataModel.scenarios.concat(result);
      this.spinnerModel.scenariosLoaded = true;
    }, error => console.error(error));

    // Load Users to models/
    this.accountService.GetAllAccountsExceptLoggedUser().subscribe(users => {
      this.dataModel.players = this.dataModel.players.concat(users.accountList);
      this.spinnerModel.playersLoaded = true;
    });

    // Load logged user data/
    let user = this.accountService.GetUserTokenInfo();
    this.formModel.loggedUserName = user.firstName + ' "' + user.nick + '" ' + user.lastName;
    this.requestModel.playerList[0].playerID = Number(user.playerID);

  }

  private ArmyChanged(selectedID:number, player: string, num:number): void {
    this.formModel.themeImg[player] = 'none';
    this.formModel.availableThemes[player] = this.dataModel.themes.filter(x => x.armyID == selectedID);
    this.formModel.armyImg[player] = "url(/assets/infinity-icons/" + this.dataModel.armies.find(a => a.armyID == selectedID).armyImage + ".svg)";
    this.requestModel.playerList[num].armyID = Number(selectedID);
  }
  private UpdateScenario(scenarioId: number) {
    if (Number(scenarioId) != 0) {
      this.requestModel.scenarioID = Number(scenarioId);
      let scenario: Scenario[] = this.dataModel.scenarios.filter(x => x.scenarioID == scenarioId);
      let baseUrl = "/assets/infinity-scenarios/";
      let imgUrl: string;
      this.requestModel.pointFormat = Number(this.requestModel.pointFormat);
      switch (this.requestModel.pointFormat) {
        case 150: {
          imgUrl = scenario[0].scenarioFormats[0].smallFormat;
          break;
        }
        case 300: {
          imgUrl = scenario[0].scenarioFormats[0].standardFormat;
          break;
        }
        default: {
          imgUrl = scenario[0].scenarioFormats[0].mediumFormat;
          break;
        }
      }
      this.formModel.scenarioImgUrl = baseUrl + imgUrl + '.png';
    }
    this.formModel.validation.scenarioValid = (Number(scenarioId) !== 0) ? true : false;
  }

  private ThemeChanged(selectedID: number, player: string, num: number): void {
    this.formModel.themeImg[player] = (selectedID == 0) ? 'none' : "url(/assets/infinity-icons/" + this.dataModel.themes.find(t => t.themeID == selectedID).themeImage + ".svg)";
    this.requestModel.playerList[num].themeID = Number(selectedID);
  }
  private OpponentChanged(selectedID: number): void {
    this.requestModel.playerList[1].playerID = Number(selectedID);
    this.formModel.validation.opponentValid = (Number(selectedID) != 0) ? true : false;
  }

  private SubmitResult() {
    if (this.requestModel.playerList[0].objectivePoints > this.requestModel.playerList[1].objectivePoints) {
      // Player1 wins
      this.requestModel.winnerID = this.requestModel.playerList[0].playerID;
      this.requestModel.playerList[0].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[1].winCondition = WinCondition.NONE;
      this.requestModel.playerList[0].battleResult = BattleResult.WON;
      this.requestModel.playerList[1].battleResult = BattleResult.LOST;

    } else if (this.requestModel.playerList[0].objectivePoints < this.requestModel.playerList[1].objectivePoints) {
      // Player2 wins
      this.requestModel.winnerID = this.requestModel.playerList[1].playerID;
      this.requestModel.playerList[1].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[0].winCondition = WinCondition.NONE;
      this.requestModel.playerList[1].battleResult = BattleResult.WON;
      this.requestModel.playerList[0].battleResult = BattleResult.LOST;

    } else {
      // Draw /
      this.requestModel.winnerID = null;
      this.requestModel.playerList[1].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[0].winCondition = WinCondition.SCENARIO;
      this.requestModel.playerList[1].battleResult = BattleResult.DRAW;
      this.requestModel.playerList[0].battleResult = BattleResult.DRAW;
    }

    this.spinnerModel.submitLoaded = false;
    this.infinityService.SubmitFriendlyGameResult(this.requestModel).subscribe(result => {
      if (result.responseCode == ResponseCode.SUCCESS) {
        this.router.navigateByUrl("/");
      } else {
        console.log(result.responseMessage);
      }
      this.spinnerModel.submitLoaded = true;
    });

   
  }


}