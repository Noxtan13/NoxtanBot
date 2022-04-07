using System;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace AntonBot
{
    class YouTube_Functions : Bot_Verwalter
    {
        LiveChatMessageListResponse LiveChats;
       
        ClientSecrets CS = new ClientSecrets();
        YouTubeService youtubeService;
        LiveBroadcastListResponse CurrentStream;

        LiveChatMessagesResource.ListRequest LiveStreamMessage;
        LiveBroadcastsResource LiveStream;
        UserCredential credential;

        public void Start ()
        {

            KonsolenAusgabe("Start Verbindung zu Youtube");
            try
            {
                Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    KonsolenAusgabe("Error: "+ Environment.NewLine + e.Message);
                }
            }

        
        }

        private async Task Run()
        {

            

            CS.ClientId = "510414211005-1u518rmkg51f81ntd7jv6h25b1vvm0fv.apps.googleusercontent.com";
            CS.ClientSecret = "UC5ozxxfjtR7goMPaA7vtzTV";

            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    CS,
                    // This OAuth 2.0 access scope allows for full read/write access to the
                    // authenticated user's account.
                    new[] {  "https://www.googleapis.com/auth/youtube.force-ssl", YouTubeService.Scope.YoutubeReadonly, },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(this.GetType().ToString())
                );

            youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyA7pYYp2PqaJBv4SA9xGlxwBIMh0lO39H8",
                ApplicationName = "ANTONBOT",
                HttpClientInitializer = credential
            }) ;

            LiveStream  = youtubeService.LiveBroadcasts;

            var LivestreamList = LiveStream.List("snippet");


            LivestreamList.BroadcastStatus = LiveBroadcastsResource.ListRequest.BroadcastStatusEnum.Active;



            CurrentStream = LivestreamList.Execute();
            
            // Call the search.list method to retrieve results matching the specified query term.
            LiveStreamMessage = youtubeService.LiveChatMessages.List(CurrentStream.Items[0].Snippet.LiveChatId, "snippet");


            LiveChats = LiveStreamMessage.Execute();

            Active = true;
        }

        public void Update() {

            LiveChatMessagesResource.ListRequest LiveStreamMessage;

            LiveStreamMessage = youtubeService.LiveChatMessages.List(CurrentStream.Items[0].Snippet.LiveChatId, "snippet, authorDetails");
            LiveStreamMessage.PageToken = LiveChats.NextPageToken;

            LiveChats = LiveStreamMessage.Execute();

            foreach (var item in LiveChats.Items)
            {
                if (item.Snippet.DisplayMessage.StartsWith("!"))
                {
                    SendMessage(CheckBefehlAllg(item.Snippet.DisplayMessage, item.AuthorDetails.DisplayName));
                }
            }

        }

        public void SendMessage(String Message) {
            LiveChatMessage Nachricht = new LiveChatMessage();

            String ID = CurrentStream.Items[0].Snippet.LiveChatId;
            Nachricht.Snippet = new LiveChatMessageSnippet();
            Nachricht.Snippet.LiveChatId = ID;
            Nachricht.Snippet.Type = "textMessageEvent";
            Nachricht.Snippet.TextMessageDetails = new LiveChatTextMessageDetails();
            Nachricht.Snippet.TextMessageDetails.MessageText = Message;

            /*
            Nachricht.AuthorDetails = new LiveChatMessageAuthorDetails();
            Nachricht.AuthorDetails.DisplayName ="ANTONBOT";
            Nachricht.AuthorDetails.ChannelId = "ANTONBOT";
            Nachricht.AuthorDetails.ChannelUrl = "ANTONBOT";
            */

            try
            {
                var request = youtubeService.LiveChatMessages.Insert(Nachricht, "snippet");
                //var request = youtubeService.LiveChatMessages.Insert(Nachricht, "snippet, authorDetails");
                LiveChatMessage Result = request.Execute();
            }
            catch (Google.GoogleApiException ex)
            {

                    Console.WriteLine("Error: " + ex.Message);
                
            }

           
        }

        public int WaitedTime=0;
        public int WaitTime() {
            return Convert.ToInt32(LiveChats.PollingIntervalMillis);
        }

    }
    
}