using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RebeliaApp.Web.Model;

namespace RebeliaApp.Web.Services
{
    public class GameDataService : IGameDataService
    {
        RebeliaDBContext dbContext;

        public GameDataService(RebeliaDBContext _context)
        {
            dbContext = _context;
        }

        public async Task<List<GameSystem>> GetAllGameSystems()
        {
            List<GameSystem> gameSystems = await dbContext.GameSystems.ToListAsync();
            return gameSystems;
        }

        public async Task<List<Army>> GetInfinityArmies()
        {
            List<Army> infinityArmies = await dbContext.Armies.Where(s => s.SystemID == 1).Include(t => t.ArmyThemes).ToListAsync();
            return infinityArmies;
        }

        public async Task<List<Army>> GetWarmachineHordesArmies()
        {
            List<Army> warmachineArmies = await dbContext.Armies.Where(s => s.SystemID == 3).Include(t => t.ArmyThemes).ToListAsync();
            return warmachineArmies;
        }
        public async Task<List<Scenario>> GetInfinityScenarios() {
            List<Scenario> scenarios = await dbContext.Scenario.Where(x => x.SystemID == 1).Include(t => t.ScenarioFormats).ToListAsync();
            return scenarios;
        }


        public async Task<List<Theme>> AddInfinityThemes(){
            List<Theme> themes = new List<Theme>()
            {
                  new Theme(){
                    ArmyID= 3,
                    SystemID= 1,
                    ThemeName= "Shock Army of Acontacimento",
                    ThemeImage= "shock-army-of-acontecimento"
                    },
                    new Theme(){

                    ArmyID= 3,
                    SystemID= 1,
                    ThemeName= "Military Orders",
                    ThemeImage= "military-orders"
                    },
                    new Theme(){

                    ArmyID= 3,
                    SystemID= 1,
                    ThemeName= "Neoterran Capitaline Army",
                    ThemeImage= "neoterran-capitaline-army"
                    },
                    new Theme(){

                    ArmyID= 3,
                    SystemID= 1,
                    ThemeName= "Varuna Immediate Reaction Division",
                    ThemeImage= "varuna"
                    },
                    new Theme(){

                    ArmyID= 3,
                    SystemID= 1,
                    ThemeName= "Svalarheimas Winter Force",
                    ThemeImage= "winterfor"
                    },
                    new Theme(){

                    ArmyID= 25,
                    SystemID= 1,
                    ThemeName= "Imperial Service",
                    ThemeImage= "imperial-service"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "Dahshat Company",
                    ThemeImage= "dahshat"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "Foreign Company",
                    ThemeImage= "foreign-company"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "Spiral Corps",
                    ThemeImage= "spiral-corps"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "StarCo",
                    ThemeImage= "starco"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "Ikari Company",
                    ThemeImage= "ikari"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "Japanese Secesionist Army",
                    ThemeImage= "japanese-secessionist-army"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "Druze Bayram Security",
                    ThemeImage= "druze"
                    },
                    new Theme(){

                    ArmyID= 20,
                    SystemID= 1,
                    ThemeName= "Operation Subsection of S.S.S.",
                    ThemeImage= "operations"
                    },
                    new Theme(){

                    ArmyID= 20,
                    SystemID= 1,
                    ThemeName= "Steel Phalanx",
                    ThemeImage= "steel-phalanx"
                    },
                    new Theme(){

                    ArmyID= 21,
                    SystemID= 1,
                    ThemeName= "Onyx Contact Force",
                    ThemeImage= "onyx"
                    },
                    new Theme(){

                    ArmyID= 21,
                    SystemID= 1,
                    ThemeName= "Shasvastii Expeditionary Force",
                    ThemeImage= "shasvastii"
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 1,
                    ThemeName= "White Company",
                    ThemeImage= "white-company"
                    },
                    new Theme(){

                    ArmyID= 21,
                    SystemID= 1,
                    ThemeName= "Morat Aggression Force",
                    ThemeImage= "morat"
                    },
                    new Theme(){

                    ArmyID= 22,
                    SystemID= 1,
                    ThemeName= "Bakunin",
                    ThemeImage= "bakunin"
                    },
                    new Theme(){

                    ArmyID= 22,
                    SystemID= 1,
                    ThemeName= "Corregidor",
                    ThemeImage= "corregidor"
                    },
                    new Theme(){

                    ArmyID= 23,
                    SystemID= 1,
                    ThemeName= "Ramah Taskforce",
                    ThemeImage= "ramah-taskforce"
                    },
                    new Theme(){

                    ArmyID= 23,
                    SystemID= 1,
                    ThemeName= "Qapu Khalqi",
                    ThemeImage= "qapu-khalqi"
                    },
                    new Theme(){

                    ArmyID= 23,
                    SystemID= 1,
                    ThemeName= "Hassassin Bahram",
                    ThemeImage= "hassassin-bahram"
                    },
                    new Theme(){

                    ArmyID= 24,
                    SystemID= 1,
                    ThemeName= "Kosmoflot",
                    ThemeImage= "kosmoflot"
                    },
                    new Theme(){

                    ArmyID= 24,
                    SystemID= 1,
                    ThemeName= "Tartary Army Corps",
                    ThemeImage= "tartary"
                    },
                    new Theme(){

                    ArmyID= 24,
                    SystemID= 1,
                    ThemeName= "USAriadna Rangers",
                    ThemeImage= "usariadna"
                    },
                    new Theme(){

                    ArmyID= 24,
                    SystemID= 1,
                    ThemeName= "Force de Response Rapide Merovingienne",
                    ThemeImage= "force-de-reponse-rapide-merovingienne"
                    },
                    new Theme(){

                    ArmyID= 24,
                    SystemID= 1,
                    ThemeName= "Caledonian Highlander Force",
                    ThemeImage= "caledonian-highlander-army"
                    },
                    new Theme(){

                    ArmyID= 25,
                    SystemID= 1,
                    ThemeName= "White Banner",
                    ThemeImage= "white-banner"
                    },
                    new Theme(){

                    ArmyID= 25,
                    SystemID= 1,
                    ThemeName= "Invincible Army",
                    ThemeImage= "invincible-army"
                    },
                    new Theme(){

                    ArmyID= 22,
                    SystemID= 1,
                    ThemeName= "Tunguska",
                    ThemeImage= "tunguska"
                    },
                    new Theme(){

                    ArmyID= 17,
                    SystemID= 1,
                    ThemeName= "Starmada",
                    ThemeImage= "starmada"
                    },
                    new Theme(){

                    ArmyID= 16,
                    SystemID= 2,
                    ThemeName= "Clockwork Legions",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 9,
                    SystemID= 3,
                    ThemeName= "Exemplar Interdiction",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 9,
                    SystemID= 2,
                    ThemeName= "The Faithful Masses",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 9,
                    SystemID= 2,
                    ThemeName= "Guardians of the Temple",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 8,
                    SystemID= 2,
                    ThemeName= "Defenders of Ios",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 8,
                    SystemID= 2,
                    ThemeName= "Forges of War",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 8,
                    SystemID= 2,
                    ThemeName= "Legions of Dawn",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 8,
                    SystemID= 2,
                    ThemeName= "Shadows of the Retribution",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 7,
                    SystemID= 2,
                    ThemeName= "The Bones of Orboros",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 7,
                    SystemID= 2,
                    ThemeName= "The Devourer's Host",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 7,
                    SystemID= 2,
                    ThemeName= "Secret Masters",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 7,
                    SystemID= 2,
                    ThemeName= "The Wild Hunt",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 9,
                    SystemID= 2,
                    ThemeName= "The Creator's Might",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 6,
                    SystemID= 2,
                    ThemeName= "Bump in the Night",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 5,
                    SystemID= 2,
                    ThemeName= "Children of the Dragon",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 5,
                    SystemID= 2,
                    ThemeName= "Oracles of Annihilation",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 5,
                    SystemID= 2,
                    ThemeName= "Primal Terrors",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 5,
                    SystemID= 2,
                    ThemeName= "Ravens of War",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 4,
                    SystemID= 2,
                    ThemeName= "The Blindwater Congregation",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 4,
                    SystemID= 2,
                    ThemeName= "The Thornfall Alliance",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 4,
                    SystemID= 2,
                    ThemeName= "Will Work For Food",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 14,
                    SystemID= 2,
                    ThemeName= "Disciples of Agony",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 14,
                    SystemID= 2,
                    ThemeName= "The Exalted",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 14,
                    SystemID= 2,
                    ThemeName= "Masters of War",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 14,
                    SystemID= 2,
                    ThemeName= "Winds of Death",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 22,
                    SystemID= 2,
                    ThemeName= "Dark Menagerie",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 27,
                    SystemID= 2,
                    ThemeName= "The Power of Dhunia",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 2,
                    ThemeName= "Talion Charter",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 2,
                    ThemeName= "Operating Theater",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 12,
                    SystemID= 2,
                    ThemeName= "Destruction Initiative",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 26,
                    SystemID= 2,
                    ThemeName= "Grave Diggers",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 26,
                    SystemID= 2,
                    ThemeName= "Heavy Metal",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 26,
                    SystemID= 2,
                    ThemeName= "Sons of Tempest",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 26,
                    SystemID= 2,
                    ThemeName= "Storm Division",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 15,
                    SystemID= 2,
                    ThemeName= "Black Industries",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 15,
                    SystemID= 2,
                    ThemeName= "Dark Host",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 15,
                    SystemID= 2,
                    ThemeName= "The Ghost Fleet",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 15,
                    SystemID= 2,
                    ThemeName= "Scurge of the Broken Coast",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 13,
                    SystemID= 2,
                    ThemeName= "Magnum Opus",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 13,
                    SystemID= 2,
                    ThemeName= "Prima Materia",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 18,
                    SystemID= 2,
                    ThemeName= "Soldiers of Fortune",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 12,
                    SystemID= 2,
                    ThemeName= "Dark Legacy",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 12,
                    SystemID= 2,
                    ThemeName= "Warriors of the Old Faith",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 12,
                    SystemID= 2,
                    ThemeName= "Flame in the Darkness",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 11,
                    SystemID= 2,
                    ThemeName= "Armored Korps",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 11,
                    SystemID= 2,
                    ThemeName= "Jaws of the Wolf",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 11,
                    SystemID= 2,
                    ThemeName= "Legions of Steel",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 11,
                    SystemID= 2,
                    ThemeName= "Winter Guard Kommand",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 11,
                    SystemID= 2,
                    ThemeName= "Wolves of Winter",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 10,
                    SystemID= 2,
                    ThemeName= "Hammer Strike",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 10,
                    SystemID= 2,
                    ThemeName= "The Irregulars",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 10,
                    SystemID= 2,
                    ThemeName= "The Kingmaker's Army",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 10,
                    SystemID= 2,
                    ThemeName= "LLaelese Resistance",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 16,
                    SystemID= 2,
                    ThemeName= "Hearts of Darkness",
                    ThemeImage= null
                    },
                    new Theme(){

                    ArmyID= 26,
                    SystemID= 2,
                    ThemeName= "Storm of the North",
                    ThemeImage= null
                    }

            };
            await dbContext.Themes.AddRangeAsync(themes);
            //dbContext.SaveChanges();
            return themes;

        }
        public async Task<List<Army>> AddInfinityArmies() {
            List<Army> armies = new List<Army>() {
                new Army(){
                SystemID= 1,
                ArmyName= "Panoceania",
                ArmyImage= "panoceania"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Yu-Jing",
                ArmyImage= "yu-jing"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Ariadna",
                ArmyImage= "ariadna"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Haqqislam",
                ArmyImage= "haqqislam"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Nomads",
                ArmyImage= "nomads"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Combined Army",
                ArmyImage= "combined-army"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Aleph",
                ArmyImage= "aleph"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Tohaa",
                ArmyImage= "tohaa"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "Merceneries",
                ArmyImage= "non-aligned-armies"
                },
                new Army(){

                SystemID= 1,
                ArmyName= "O-12",
                ArmyImage= "o-12"
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Convergence of Crysis",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Cygnar",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Cryx",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Golden Crucible",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Infernals",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Khador",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Merceneries",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Protectorate of Menoth",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Retribution of Scyrah",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Circle of Orboros",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Grymkin",
                ArmyImage= null
                },
                new Army(){

                SystemID= 2,
                ArmyName= "Legion of Everblight",
                ArmyImage= null
                },
                new Army(){
                SystemID= 2,
                ArmyName= "Minions",
                ArmyImage= null
                },
                new Army(){
                SystemID= 2,
                ArmyName= "Skorne",
                ArmyImage= null
                },
                new Army(){
                SystemID= 2,
                ArmyName= "Trollbloods",
                ArmyImage= null
                }
            };

            await dbContext.Armies.AddRangeAsync(armies);
            //dbContext.SaveChanges();
            return armies;
        }
        public async Task<List<Scenario>> AddInfinityMissions()
        {
            List<Scenario> missions = new List<Scenario>() {
                new Scenario { SystemID = 1, ScenarioName= "Acquisition" },
                new Scenario { SystemID = 1, ScenarioName= "Annihilation" },
                new Scenario { SystemID = 1, ScenarioName= "Biotechvore" },
                new Scenario { SystemID = 1, ScenarioName= "Capture and Protect" },
                new Scenario { SystemID = 1, ScenarioName= "Countermeasures" },
                new Scenario { SystemID = 1, ScenarioName= "Decapitation" },
                new Scenario { SystemID = 1, ScenarioName= "Firefight" },
                new Scenario { SystemID = 1, ScenarioName= "Frontline" },
                new Scenario { SystemID = 1, ScenarioName= "Highly Classified" },
                new Scenario { SystemID = 1, ScenarioName= "Looting and Sabotaging" },
                new Scenario { SystemID = 1, ScenarioName= "Mindwipe" },
                new Scenario { SystemID = 1, ScenarioName= "Panic Room" },
                new Scenario { SystemID = 1, ScenarioName= "Power Pack" },
                new Scenario { SystemID = 1, ScenarioName= "Quadrant Control" },
                new Scenario { SystemID = 1, ScenarioName= "Rescue" },
                new Scenario { SystemID = 1, ScenarioName= "Safe Area" },
                new Scenario { SystemID = 1, ScenarioName= "Supplies" },
                new Scenario { SystemID = 1, ScenarioName= "Supremacy" },
                new Scenario { SystemID = 1, ScenarioName= "The Armory" },
                new Scenario { SystemID = 1, ScenarioName= "Unmasking" }
            };

            await dbContext.Scenario.AddRangeAsync(missions);
            //dbContext.SaveChanges();
            return missions;
        }
        public async Task<List<MapFormat>> AddInfinityMapFormats() {
            List<MapFormat> maps = new List<MapFormat>()
            {
                new MapFormat(){
                    ScenarioID= 1,
                    SystemID= 1,
                    SmallFormat= "acquisition-150",
                    MediumFormat= "acquisition-250",
                    StandardFormat= "acquisition-300"
                },
                new MapFormat(){
                    ScenarioID= 2,
                    SystemID= 1,
                    SmallFormat= "supremacy-150",
                    MediumFormat= "supremacy-250",
                    StandardFormat= "supremacy-300"
                },
                new MapFormat(){
                    ScenarioID= 3,
                    SystemID= 1,
                    SmallFormat= "supplies-150",
                    MediumFormat= "supplies-250",
                    StandardFormat= "supplies-300"
                },
                new MapFormat(){
                    ScenarioID= 4,
                    SystemID= 1,
                    SmallFormat= "safearea-150",
                    MediumFormat= "safearea-250",
                    StandardFormat= "safearea-300"
                },
                new MapFormat(){
                    ScenarioID= 5,
                    SystemID= 1,
                    SmallFormat= "rescue-150",
                    MediumFormat= "rescue-250",
                    StandardFormat= "rescue-300"
                },
                new MapFormat(){
                    ScenarioID= 6,
                    SystemID= 1,
                    SmallFormat= "quadrant-150",
                    MediumFormat= "quadrant-250",
                    StandardFormat= "quadrant-300"
                },
                new MapFormat(){
                    ScenarioID= 7,
                    SystemID= 1,
                    SmallFormat= "powerpack-150",
                    MediumFormat= "powerpack-250",
                    StandardFormat= "powerpack-300"
                },
                new MapFormat(){
                    ScenarioID= 8,
                    SystemID= 1,
                    SmallFormat= "panicroom-150",
                    MediumFormat= "panicroom-250",
                    StandardFormat= "panicroom-300"
                },
                new MapFormat(){
                    ScenarioID= 9,
                    SystemID= 1,
                    SmallFormat= "midnwipe-150",
                    MediumFormat= "midnwipe-250",
                    StandardFormat= "midnwipe-300"
                },
                new MapFormat(){
                    ScenarioID= 10,
                    SystemID= 1,
                    SmallFormat= "looting-150",
                    MediumFormat= "looting-250",
                    StandardFormat= "looting-300"
                },
                new MapFormat(){
                    ScenarioID= 11,
                    SystemID= 1,
                    SmallFormat= "hclassified-150",
                    MediumFormat= "hclassified-250",
                    StandardFormat= "hclassified-300"
                },
                new MapFormat(){
                    ScenarioID= 12,
                    SystemID= 1,
                    SmallFormat= "frontline-150",
                    MediumFormat= "frontline-250",
                    StandardFormat= "frontline-300"
                },
                new MapFormat(){
                    ScenarioID= 13,
                    SystemID= 1,
                    SmallFormat= "firefight-150",
                    MediumFormat= "firefight-250",
                    StandardFormat= "firefight-300"
                },
                new MapFormat(){
                    ScenarioID= 14,
                    SystemID= 1,
                    SmallFormat= "decapitation-150",
                    MediumFormat= "decapitation-250",
                    StandardFormat= "decapitation-300"
                },
                new MapFormat(){
                    ScenarioID= 15,
                    SystemID= 1,
                    SmallFormat= "countermeasures-150",
                    MediumFormat= "countermeasures-250",
                    StandardFormat= "countermeasures-300"
                },
                new MapFormat(){
                    ScenarioID= 16,
                    SystemID= 1,
                    SmallFormat= "capture-150",
                    MediumFormat= "capture-250",
                    StandardFormat= "capture-300"
                },
                new MapFormat(){
                    ScenarioID= 17,
                    SystemID= 1,
                    SmallFormat= "biotechvore-150",
                    MediumFormat= "biotechvore-250",
                    StandardFormat= "biotechvore-300"
                },
                new MapFormat(){
                    ScenarioID= 18,
                    SystemID= 1,
                    SmallFormat= "annihilation-150",
                    MediumFormat= "annihilation-250",
                    StandardFormat= "annihilation-300"
                },
                new MapFormat(){
                    ScenarioID= 19,
                    SystemID= 1,
                    SmallFormat= "armory-150",
                    MediumFormat= "armory-250",
                    StandardFormat= "armory-300"
                },
                new MapFormat(){
                    ScenarioID= 20,
                    SystemID= 1,
                    SmallFormat= "unmasking-150",
                    MediumFormat= "unmasking-250",
                    StandardFormat= "unmasking-300"
                }
            };
            await dbContext.MapFormat.AddRangeAsync(maps);
            dbContext.SaveChanges();
            return maps;
        }
    }
}
