using Common.Enums;
using MusWinService.Database;
using MusWinService.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;

namespace MusWinService
{
    public class MusService : IMusService
    {
        #region Service methods
        public string Login(string userName, string gameName, string password)
        {
            try
            {
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game == null)
                {
                    game = new MusGame(gameName);
                    MusDatabase.Games.Add(game);
                }
                if (!game.Users.Any(x => x.UserName == userName))
                    game.Users.Add(new MusUser(userName));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "OK";
        }
        public List<string> GetConnectedUsers(string gameName)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            if (game != null)
            {
                return game.Users.Select(x => x.UserName).ToList();
            }
            return new List<string>();
        }
        public string CreateTeam(string gameName, string teamName, string[] users)
        {
            try
            {
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game != null)
                {
                    var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
                    if (team == null)
                    {
                        if (game.Teams.Count == 2)
                            return "YA SE HAN CREADO OTROS DOS EQUIPOS";

                        team = new MusTeam(teamName);
                        game.Teams.Add(team);
                    }
                    foreach (string user in users)
                    {
                        var seluser = game.Users.FirstOrDefault(x => x.UserName == user);
                        if (seluser != null && !team.Users.Contains(seluser))
                            team.Users.Add(seluser);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return "OK";
        }
        public string StartGame(string gameName, int pointsToWin)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            if (game != null)
            {
                game.PointsToWin = pointsToWin;
            }
            return "OK";
        }

        public MusData GetMusData(string gameName, string userName)
        {
            return GetMusData(gameName, userName, false);
        }
        MusData GetMusData(string gameName, string userName, bool getCards)
        {
            MusData musData = new MusData();
            try
            {
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game != null)
                {
                    musData.MusTeams = new List<MusTeamData>();
                    foreach (var team in game.Teams)
                    {
                        musData.MusTeams.Add(new MusTeamData()
                        {
                            TeamName = team.TeamName,
                            UserName1 = team.Users?.Count > 0 ? team.Users[0].UserName : null,
                            UserName2 = team.Users?.Count > 1 ? team.Users[1].UserName : null,
                            RoundUserName1 = team.Users?.Count > 0 ? team.Users[0].CurrentRound : 0,
                            RoundUserName2 = team.Users?.Count > 1 ? team.Users[1].CurrentRound : 0,
                            Points = team.Puntuacion
                        });
                    }
                    musData.PointsToWin = game.PointsToWin;
                }
            }
            catch (Exception ex)
            {
                musData.Error = ex.ToString();
            }
            return musData;
        }

        public MusData GetAllUserCards(string gameName, string userName)
        {
            return GetMusData(gameName, userName, true);
        }
        public List<MusCard> GetCards(string gameName, string userName)
        {
            return GetCards(gameName, userName, 4);
        }
        public List<MusCard> ChangeCards(string gameName, string userName, List<MusCard> discarded)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            game.Traces.Add($"{userName} se descarta {discarded?.Count} cartas");
            game.Cards.CardsDiscarded.AddRange(discarded);
            return GetCards(gameName, userName, discarded.Count);
        }
        public void ChangePoints(string gameName, string teamName, string userName, int points)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            if (team.Puntuacion != points)
            {
                game.Traces.Add($"{userName} va a cambiar los puntos del equipo {teamName}: {points}");
                team.Puntuacion = points;
            }
        }
        public void ResetRound(string gameName)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            game.Cards = new MusCards();
        }
        public void NextRound(string gameName, string teamName, string userName, int round)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            game.Traces.Add($"{userName} va a empezar siguiente ronda");
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            var user = team.Users.FirstOrDefault(x => x.UserName == userName);
            user.CurrentRound = round;
            bool allInSameRound = true;
            foreach (var t in game.Teams)
            {
                if (team.Users.Any(x => x.CurrentRound != round))
                {
                    allInSameRound = false;
                    break;
                }
            }
            if (allInSameRound)
                ResetRound(gameName);
        }
        public void FinishGame(string gameName)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            if (game != null)
                MusDatabase.Games.Remove(game);
        }
        public List<string> GetTraces(string gameName)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            return game.Traces;
        }

        #endregion

        #region Traces
        private static TraceSource mySource = new TraceSource("TraceMusService");
        public static void StartTraces()
        {
            try
            {
                mySource.TraceMessage(TraceEventType.Information, 57, "Arrancando el servicio de gestión documental");
                mySource?.Close();
            }
            catch { }
        }
        public static void StopTraces()
        {
            try
            {
                mySource.TraceMessage(TraceEventType.Information, 58, "Parando el servicio de gestión documental");
                mySource?.Close();
            }
            catch { }
        }
        #endregion  

        static List<MusCard> GetCards(string gameName, string userName, int numCards)
        {
            List<MusCard> retVal = new List<MusCard>();
            try
            {
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game != null)
                {
                    for (int i = 0; i < numCards; i++)
                    {
                        if (game.Cards.CardsToPlay.Count == 0)
                        {
                            game.Cards.CardsToPlay.AddRange(game.Cards.CardsDiscarded);
                            game.Cards.CardsDiscarded.Clear();
                        }
                        int randomIndex = rnd.Next(game.Cards.CardsToPlay.Count - 1);
                        MusCard card = game.Cards.CardsToPlay[randomIndex];
                        retVal.Add(card);
                        game.Cards.CardsToPlay.Remove(card);
                    }
                    mySource.TraceMessage(TraceEventType.Information, 58, $"QUEDAN {game.Cards.CardsToPlay.Count} CARTAS");
                }
            }
            catch (Exception ex)
            {
                mySource.TraceMessage(TraceEventType.Information, 58, $"ERROR {ex.ToString()}");
            }
            return retVal;
        }
        static Random rnd = new Random();
    }
}
