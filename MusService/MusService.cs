using MusCommon.Enums;
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
                mySource.TraceMessage(TraceEventType.Information, 58, $"Login {gameName} -> {userName}");
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game == null)
                {
                    mySource.TraceMessage(TraceEventType.Information, 58, $"Create game {gameName}");

                    game = new MusGame(gameName);
                    MusDatabase.Games.Add(game);
                }

                if (!game.Users.Any(x => x.UserName == userName))
                {
                    if (game.Users.Count >= 4)
                    {
                        mySource.TraceMessage(TraceEventType.Error, 58, $"Ya hay 4 jugadores conectados {gameName} -> {userName}");
                        return "YA HAY 4 JUGADORES CONECTADOS!, " + string.Join(", ", game.Users.Select(x => x.UserName));
                    }

                    mySource.TraceMessage(TraceEventType.Information, 58, $"Añado el user {userName} al game {gameName}");
                    game.Users.Add(new MusUser(userName));
                }
                else
                    mySource.TraceMessage(TraceEventType.Information, 58, $"El user ya estaba añadido {userName} al game {gameName}");

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
                    foreach(var t in game.Teams)
                    {
                        if (t.TeamName != teamName)
                        {
                            if (t.Users.Any(x => users.Contains(x.UserName)))
                                return "YA ESTAS EN EL OTRO EQUIPO";
                        }
                    }
                    var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
                    if (team == null)
                    {
                        if (game.Teams.Count == 2)
                        {
                            mySource.TraceMessage(TraceEventType.Warning, 58, $"No se crea el team {teamName} porque ya hay otros dos");
                            return "YA SE HAN CREADO OTROS DOS EQUIPOS";
                        }

                        mySource.TraceMessage(TraceEventType.Information, 58, $"Create team {teamName}");

                        team = new MusTeam(teamName);
                        game.Teams.Add(team);
                    }
                    foreach (string user in users)
                    {
                        var seluser = game.Users.FirstOrDefault(x => x.UserName == user);
                        if (seluser != null && !team.Users.Contains(seluser))
                        {
                            if (team.Users.Count == 2)
                            {
                                mySource.TraceMessage(TraceEventType.Warning, 58, $"No se añade el user {user} al team {teamName} porque ya hay otros dos");
                                return "EL EQUIPO YA TIENE DOS MIEMBROS";
                            }

                            mySource.TraceMessage(TraceEventType.Information, 58, $"Añadir el user {user} al team {teamName}");

                            team.Users.Add(seluser);
                        }
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

        public MusData GetMusData(string gameName, string teamName, string userName)
        {
            return GetMusData(gameName, teamName, userName, false);
        }

        public MusData GetAllUserCards(string gameName, string teamName, string userName)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            AddTrace(game, $"{userName} pide mostrar cartas de todos los jugadores");
            return GetMusData(gameName, teamName, userName, true);
        }
        public List<MusCard> GetCards(string gameName, string teamName, string userName)
        {
            return GetCards(gameName, teamName, userName, 4);
        }
        public List<MusCard> ChangeCards(string gameName, string teamName, string userName, List<MusCard> discarded)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            var user = team.Users.FirstOrDefault(x => x.UserName == userName);
            foreach (MusCard discard in discarded)
                user.Cards.Remove(discard);
            foreach (MusCard mC in discarded)
            {
                if (mC != MusCard.Empty && mC != MusCard.Back)
                    game.Cards.CardsDiscarded.Add(mC);
            }
            return GetCards(gameName, teamName, userName, discarded.Count);
        }
        public void ChangePoints(string gameName, string teamName, string userName, int points)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            if (team.Puntuacion != points)
            {
                AddTrace(game, $"{userName} va a cambiar los puntos del equipo {teamName}: {points}");
                team.Puntuacion = points;
            }
        }
        public void ChangeGamePoints(string gameName, string teamName, string userName, int gamePoints)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            if (team.GamePoints != gamePoints)
            {
                AddTrace(game, $"{userName} va a cambiar los juegos ganados del equipo {teamName}: {gamePoints}");
                team.GamePoints = gamePoints;
            }
        }
        public void ResetRound(string gameName)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            foreach (MusTeam t in game.Teams)
            {
                foreach (MusUser u in t.Users)
                    u.Cards.Clear();
            }
            game.Cards = new MusCards();
        }
        public void NextRound(string gameName, string teamName, string userName, int round)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            AddTrace(game, $"{userName} va a empezar siguiente ronda: " + round);
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            var user = team.Users.FirstOrDefault(x => x.UserName == userName);
            user.CurrentRound = round;
            bool allInSameRound = true;

            string usersInRound = "";
            foreach (var t in game.Teams)
            {
                foreach (var u in t.Users)
                {
                    usersInRound += $"{u.UserName} ({u.CurrentRound}), ";
                    if (u.CurrentRound != round)
                        allInSameRound = false;
                }
            }
            if (allInSameRound)
            {
                NextHand(game, round);
                ResetRound(gameName);
                if (round % 2 == 0)
                {
                    mySource.TraceMessage(TraceEventType.Information, 57, "Limpiando trazas en ronda " + round);
                    game.Traces.Clear();
                }
                else
                {
                    // poner dos lineas vacias entre mano y mano
                    game.Traces.Add("");
                    game.Traces.Add("");
                }
            }
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
        public string ChangeHand(string gameName, string userName, string newHandUser)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            if (game != null)
            {
                AddTrace(game, $"{userName} cambia la mano a {newHandUser}");
                game.HandUser = newHandUser;
                return "OK";
            }
            return "MESA NO ENCONTRADA";
        }
        public void RequestShowCards(string gameName, string teamName, string userName, int round)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            AddTrace(game, $"{userName} pide enseñar cartas en ronda {round}");
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
            var user = team.Users.FirstOrDefault(x => x.UserName == userName);
            user.ShowCardsRound = round;
        }
        public void SendSpecialMessage(string gameName, string teamName, string userName, MusSpecialMessages message)
        {
            var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
            AddTrace(game, $"{userName} pide enviar mensaje especial: {message}");
            var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);

            foreach (var t in game.Teams)
            {
                if (t != team)
                {
                    foreach (var u in t.Users)
                        u.SpecialMessage = message;
                }
            }
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
        static void AddTrace(MusGame game, string trace)
        {
            mySource.TraceMessage(TraceEventType.Information, 58, trace);
            game.Traces.Add($"{DateTime.Now.ToString("HH:mm:ss")} {trace}");
        }
        #endregion  
        MusData GetMusData(string gameName, string teamName, string userName, bool getCards)
        {
            MusData musData = new MusData();
            try
            {
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game != null)
                {
                    var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
                    var user = team?.Users.FirstOrDefault(x => x.UserName == userName);
                    musData.MusTeams = new List<MusTeamData>();
                    foreach (var t in game.Teams)
                    {
                        musData.MusTeams.Add(new MusTeamData()
                        {
                            TeamName = t.TeamName,
                            UserName1 = t.Users?.Count > 0 ? t.Users[0].UserName : null,
                            UserName2 = t.Users?.Count > 1 ? t.Users[1].UserName : null,
                            RoundUserName1 = t.Users?.Count > 0 ? t.Users[0].CurrentRound : 0,
                            RoundUserName2 = t.Users?.Count > 1 ? t.Users[1].CurrentRound : 0,
                            ShowCardsName1 = t.Users?.Count > 0 ? t.Users[0].ShowCardsRound : 0,
                            ShowCardsName2 = t.Users?.Count > 1 ? t.Users[1].ShowCardsRound : 0,
                            Points = t.Puntuacion,
                            GamePoints = t.GamePoints,
                            CardsUser1 = getCards && t.Users?.Count > 0 ? t.Users[0].Cards : null,
                            CardsUser2 = getCards && t.Users?.Count > 1 ? t.Users[1].Cards : null,
                        });
                    }
                    musData.PointsToWin = game.PointsToWin;
                    musData.HandUser = game.HandUser;
                    if (user != null)
                    {
                        musData.SpecialMessage = user.SpecialMessage;
                        user.SpecialMessage = MusSpecialMessages.None;
                    }
                }
            }
            catch (Exception ex)
            {
                musData.Error = ex.ToString();
            }
            return musData;
        }

        static List<MusCard> GetCards(string gameName, string teamName, string userName, int numCards)
        {
            List<MusCard> retVal = new List<MusCard>();


            try
            {
                var game = MusDatabase.Games.FirstOrDefault(x => x.GameName == gameName);
                if (game != null)
                {
                    var team = game.Teams.FirstOrDefault(x => x.TeamName == teamName);
                    if (team == null)
                        mySource.TraceMessage(TraceEventType.Error, 58, $"ERROR No leo el Team {teamName} del user {userName} en GetCards");

                    var user = team.Users.FirstOrDefault(x => x.UserName == userName);
                    if (user == null)
                        mySource.TraceMessage(TraceEventType.Error, 58, $"ERROR No leo el User {userName} del equipo {teamName} en GetCards");
                    for (int i = 0; i < numCards; i++)
                    {
                        if (game.Cards.CardsToPlay.Count == 0)
                        {
                            AddTrace(game, "Se vuelven a barajar las cartas descartadas");
                            game.Cards.CardsToPlay.AddRange(game.Cards.CardsDiscarded);
                            game.Cards.CardsDiscarded.Clear();
                        }
                        int randomIndex = rnd.Next(game.Cards.CardsToPlay.Count - 1);
                        MusCard card = game.Cards.CardsToPlay[randomIndex];
                        retVal.Add(card);
                        user.Cards.Add(card);
                        game.Cards.CardsToPlay.Remove(card);
                    }
                }
            }
            catch (Exception ex)
            {
                mySource.TraceMessage(TraceEventType.Information, 58, $"ERROR {ex.ToString()}");
            }
            return retVal;
        }
        static Random rnd = new Random();
        static void NextHand(MusGame game, int round)
        {
            string names = $"{game.Teams[0].Users[0].UserName}, {game.Teams[0].Users[1].UserName}, {game.Teams[1].Users[0].UserName}, {game.Teams[1].Users[1].UserName}";
            mySource.TraceMessage(TraceEventType.Warning, 58, $"antes de cambiar mano {game.HandUser} ({names})");
            if (game.Teams[0].Users[0].UserName == game.HandUser)
                game.HandUser = game.Teams[1].Users[0].UserName;
            else if (game.Teams[1].Users[0].UserName == game.HandUser)
                game.HandUser = game.Teams[0].Users[1].UserName;
            else if (game.Teams[0].Users[1].UserName == game.HandUser)
                game.HandUser = game.Teams[1].Users[1].UserName;
            else
                game.HandUser = game.Teams[0].Users[0].UserName;
            mySource.TraceMessage(TraceEventType.Warning, 58, $"despues de cambiar mano {game.HandUser}");
        }
    }
}
