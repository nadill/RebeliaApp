import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Army, Theme, PlayerGameScore, FriendlyGameResult, Scenario, MapFormat } from '../../../model/Shared';
import { InfinityService } from '../../../providers/infinity.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AccountService } from '../../../providers/account.service';
import { UserAccount } from '../../../model/Shared/UserAccount';

import { concat } from 'rxjs';

@Component({
  selector: 'add-infinity-component',
  templateUrl: './infinity.component.html'
})

export class AddInfinityComponent implements OnInit {
  public armies: Army[] = [];
  public themes: Theme[] = [];
  public scenarios: Scenario[] = [{ scenarioID: 0, scenarioName: "", scenarioFormats: [{ mapID: 0, smallFormat: "", mediumFormat: "", standardFormat: "" }] }];
  public scenarioImgUrl: string = "none";
  public playersList: UserAccount[] = [];
  private spinnerModel = {
    armies: false,
    scenarios: false,
    players: false
  }
  
  public playerScore: {
    player1: PlayerGameScore,
    player2: PlayerGameScore
  } = { 
    player1: {
      playerID: 0,
      playerName: '',
      armyID: 0,
      themeID: 0,
      objectivePoints: 0,
      armyPoints: 0
      },
    player2: {
      playerID: 0,
      playerName: '',
      armyID: 0,
      themeID: 0,
      objectivePoints: 0,
      armyPoints: 0
    }
  };
  public battleResult: FriendlyGameResult = {
    date: 0,
    player1Result: null,
    player2Result: null,
    winnerID: 0,
    pointFormat: 150,
    rounds: 3,
    gameSystemID: 0,
    scenarioID: 0
  };
  public armyPool: {
    player1: Army[],
    player2: Army[]
  } = {
    player1: [],
    player2: []
  };
  public availableThemes: {
    player1: Theme[],
    player2: Theme[]
  } = {
    player1: [],
    player2: []
  };
  public armyImg: {
    player1: string,
    player2: string
  } = {
    player1: '',
    player2: ''
  };
  public themeImg: {
    player1: string,
    player2: string
  } = {
    player1: '',
    player2: ''
  };
  public formValid: boolean = true;
  public inputFieldValid: {
    roundInput: boolean,
    objectiveInputP1: boolean,
    armyInputP1: boolean,
    objectiveInputP2: boolean,
    armyInputP2: boolean
  } = {
    roundInput: true,
    objectiveInputP1: true,
    armyInputP1: true,
    objectiveInputP2: true,
    armyInputP2: true
  };


  constructor(private infinityService: InfinityService, private accountService: AccountService) {

  }

  ngOnInit() {
    this.infinityService.GetInfinityArmies().subscribe(result => {
      this.armies = result;
      this.armies.forEach(army => {
        this.themes = this.themes.concat(army.armyThemes);
      });

      this.armyPool.player1 = this.armies;
      this.armyPool.player2 = this.armies;

      this.availableThemes.player1 = this.themes;
      this.availableThemes.player2 = this.themes;

      this.armyImg.player1 = "url(/assets/infinity-icons/" + this.armies[0].armyImage + ".svg)";
      this.armyImg.player2 = "url(/assets/infinity-icons/" + this.armies[0].armyImage + ".svg)";

      this.themeImg.player1 = "none";
      this.themeImg.player2 = "none";

      this.ArmyChanged(this.armies[0].armyID, "player1");
      this.ArmyChanged(this.armies[0].armyID, "player2");

      this.spinnerModel.armies = true;
    });

    this.infinityService.GetInfinityScenarios().subscribe(result => {
      this.scenarios = result;
      this.spinnerModel.scenarios = true;
    }, error => console.error(error));
    let user = this.accountService.GetUserTokenInfo();

    this.playerScore.player1.playerID = user.playerID;
    this.playerScore.player1.playerName = user.firstName + ' "' + user.nick + '" ' + user.lastName;

    this.accountService.GetAllAccountsExceptLoggedUser().subscribe(users => {
      this.playersList = this.playersList.concat(users.accountList);
      this.spinnerModel.players = true;
    });

  }

  private ArmyChanged(selectedID:number, player: string): void {
    this.themeImg[player] = 'none';
    this.availableThemes[player] = this.themes.filter(x => x.armyID == selectedID);
    this.armyImg[player] = "url(/assets/infinity-icons/" + this.armies.find(a => a.armyID == selectedID).armyImage + ".svg)";
    this.playerScore[player].armyID = selectedID;
  }
  private UpdateScenario(scenarioId: number) {
    let scenario: Scenario[] = this.scenarios.filter(x => x.scenarioID == scenarioId);
    let baseUrl = "/assets/infinity-scenarios/";
    let imgUrl: string;
    let pointFormat: number = Number(this.battleResult.pointFormat);
    switch (pointFormat) {
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
    this.scenarioImgUrl = baseUrl + imgUrl + '.png';
  }

  private ThemeChanged(selectedID: number, player: string): void {
    this.themeImg[player] = (selectedID == 0) ? 'none' : "url(/assets/infinity-icons/" + this.themes.find(t => t.themeID == selectedID).themeImage + ".svg)";
    this.playerScore[player].themeID = selectedID;
  }

  private SubmitResult() {
    if (this.playerScore.player1.objectivePoints > this.playerScore.player2.objectivePoints) {
      this.battleResult.winnerID = this.playerScore.player1.playerID;
    } else if (this.playerScore.player1.objectivePoints < this.playerScore.player2.objectivePoints) {
      this.battleResult.winnerID = this.playerScore.player2.playerID;
    } else {
      this.battleResult.winnerID = 0;
    }
    this.battleResult.date = Date.now();
    this.battleResult.gameSystemID = 1;
    this.battleResult.player1Result = this.playerScore.player1;
    this.battleResult.player2Result = this.playerScore.player2;

   
  }


}