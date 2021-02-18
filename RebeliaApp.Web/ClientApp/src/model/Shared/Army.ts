import { Theme, Caster} from './index';

export class Army {
  armyID: number;
  armyName: string;
  armyThemes: Theme[];
  casterList: Caster[] | null;
  armyImage: string;
}