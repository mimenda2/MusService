using System.ServiceModel;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using MusCommon.Enums;
using System.ServiceModel.Web;

namespace MusWinService
{
    [ServiceContract]
    public interface IMusService
    {
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        string Login(string userName, string gameName, string password);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        List<string> GetConnectedUsers(string gameName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        string CreateTeam(string gameName, string teamName, string[] users);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        string StartGame(string gameName, int pointsToWin);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        MusData GetMusData(string gameName, string userName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        List<MusCard> GetCards(string gameName, string teamName, string userName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        List<MusCard> ChangeCards(string gameName, string teamName, string userName, List<MusCard> discarded);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        void ChangePoints(string gameName, string teamName, string userName, int points);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        void ChangeGamePoints(string gameName, string teamName, string userName, int gamePoints);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        void ResetRound(string gameName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        void NextRound(string gameName, string teamName, string userName, int round);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        void FinishGame(string gameName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        List<string> GetTraces(string gameName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        MusData GetAllUserCards(string gameName, string userName);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        string ChangeHand(string gameName, string userName, string newHandUser);
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
        [OperationContract, WebGet]
        void RequestShowCards(string gameName, string teamName, string userName, int round);
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

        [DataMember]
        public string HandUser { get; set; }
        
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
        public int ShowCardsName1 { get; set; }

        [DataMember]
        public int ShowCardsName2 { get; set; }
        
        [DataMember]
        public int Points { get; set; }

        [DataMember]
        public int GamePoints { get; set; }

        [DataMember]
        public List<MusCard> CardsUser1 { get; set; }

        [DataMember]
        public List<MusCard> CardsUser2 { get; set; }
    }
}
