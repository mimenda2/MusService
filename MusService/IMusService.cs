using System.ServiceModel;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Common.Enums;

namespace MusWinService
{
    [ServiceContract]
    public interface IMusService
    {
        [OperationContract]
        string Login(string userName, string gameName, string password);
        [OperationContract]
        List<string> GetConnectedUsers(string gameName);
        [OperationContract]
        string CreateTeam(string gameName, string teamName, string[] users);
        [OperationContract]
        string StartGame(string gameName, int pointsToWin);
        [OperationContract]
        MusData GetMusData(string gameName, string userName);
        [OperationContract]
        List<MusCard> GetCards(string gameName, string teamName, string userName);
        [OperationContract]
        List<MusCard> ChangeCards(string gameName, string teamName, string userName, List<MusCard> discarded);
        [OperationContract]
        void ChangePoints(string gameName, string teamName, string userName, int points);
        [OperationContract]
        void ResetRound(string gameName);
        [OperationContract]
        void NextRound(string gameName, string teamName, string userName, int round);
        [OperationContract]
        void FinishGame(string gameName);
        [OperationContract]
        List<string> GetTraces(string gameName);
        [OperationContract]
        MusData GetAllUserCards(string gameName, string userName);
    }

    [DataContract]
    public class MusData
    {
        [DataMember]
        public List<MusTeamData> MusTeams { get; set; }

        [DataMember]
        public long PointsToWin { get; set; }

        [DataMember]
        public int Round { get; set; }

        [DataMember]
        public string Error { get; set; }
    }
    [DataContract]
    public class MusTeamData
    {
        [DataMember]
        public string TeamName { get; set; }

        [DataMember]
        public string UserName1 { get; set; }

        [DataMember]
        public string UserName2 { get; set; }

        [DataMember]
        public int RoundUserName1 { get; set; }

        [DataMember]
        public int RoundUserName2 { get; set; }

        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public List<MusCard> CardsUser1 { get; set; }

        [DataMember]
        public List<MusCard> CardsUser2 { get; set; }
    }
}
