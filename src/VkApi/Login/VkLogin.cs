using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VkApi;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using NLog;

namespace VkApi
{
    public static class VkLogin
    {
        private const string OauthUrlTemplate = "http://oauth.vk.com/authorize?client_id={0}&scope={1}&redirect_uri={2}&response_type=token";
        private const string OauthRedirectUrl = "https://oauth.vk.com/blank.html ";
        private const string OauthSendLoginFormUrl = "https://login.vk.com/?act=login&soft=1&utf8=1";

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static async Task<VkSessionInfo> SimpleLogin(string appId, string userLogin, string userPassword, params VkScope[] scopes)
        {
            using (var client = new HttpClient())
            {
            start:

                Logger.Trace("Try vk login without forms");
                var scopeSrc = string.Join(", ", scopes.Select(_ => _.GetEnumValue()));
                var authUrl = string.Format(OauthUrlTemplate, appId, scopeSrc, OauthRedirectUrl);
                Logger.Trace("Request oauth: {0}", authUrl);
                var response = await client.GetAsync(authUrl);
                response.EnsureSuccessStatusCode();

                //parse and fill login form
                var loginFormHtml = await response.Content.ReadAsStringAsync();

                Logger.Trace("Parse login form");
                var doc = new HtmlDocument();
                doc.LoadHtml(loginFormHtml);

                var dic = doc.DocumentNode.QuerySelectorAll("input").ToDictionary(
                    source => source.GetAttributeValue("name", ""),
                    source => source.GetAttributeValue("value", ""));

                dic["email"] = userLogin;
                dic["pass"] = userPassword;

                Logger.Trace("Send login form");

                response = await client.PostAsync(OauthSendLoginFormUrl, new FormUrlEncodedContent(dic));
                response.EnsureSuccessStatusCode();


                var callbackLink = response.RequestMessage.RequestUri.Fragment;

                //if need approve credentials
                if (string.IsNullOrWhiteSpace(callbackLink))
                {
                    Logger.Trace("Need approve credentials. Parse form");
                    var credentialsSrc = await response.Content.ReadAsStringAsync();
                    doc = new HtmlDocument();
                    doc.LoadHtml(credentialsSrc);
                    var formContainer = doc.GetElementbyId("mcont");
                    if (formContainer == null) throw new VkLoginException("Could not finf approve credentials form");
                    var approveUrl = formContainer.QuerySelector("form").GetAttributeValue("action", null);
                    if (string.IsNullOrWhiteSpace(approveUrl))
                        throw new VkLoginException("Could not finf approve credentials form");

                    response =
                        await
                        client.PostAsync(approveUrl, new FormUrlEncodedContent(new KeyValuePair<string, string>[] {}));
                    response.EnsureSuccessStatusCode();
                    callbackLink = response.RequestMessage.RequestUri.Fragment;
                }
                
             

                var resultDict = callbackLink.TrimStart('#').Split('&').Select(_ => _.Split('=')).ToDictionary(
                    _ => _[0], _ => _[1]);
                Logger.Trace("Login success. Create session info.");
                return new VkSessionInfo(resultDict["access_token"], resultDict["expires_in"], resultDict["user_id"],
                                         appId);
            }
        }

        public static async Task<IVkApi> SimpleLoginAndGetApi(string appId, string userLogin, string userPassword, params VkScope[] scopes)
        {
            return CreateApi(await SimpleLogin(appId, userLogin, userPassword, scopes));
        }

        public static IVkApi CreateApi(VkSessionInfo info)
        {
            return new VkApi(info.AccessToken);
        }

    }
}