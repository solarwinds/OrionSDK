using System.Net;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    internal static class OAuthHtmlRenderer
    {
        internal static byte[] RenderCallbackPage(string error, string errorDescription, string clientId)
        {
            bool isSuccess = error == null;
            string title = isSuccess ? "Authentication Successful" : "Authentication Failed";
            string body = isSuccess
                ? "You have been signed in successfully. You may close this browser tab and return to SWQL Studio."
                : $"Sign-in could not be completed: <strong>{WebUtility.HtmlEncode(errorDescription ?? error)}</strong>";
            string iconColor = isSuccess ? "#2e7d32" : "#c62828";
            string icon = isSuccess ? "✔" : "✖";

            string html = $@"<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""utf-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
  <title>{title}</title>
  <style>
    *, *::before, *::after {{ box-sizing: border-box; margin: 0; padding: 0; }}
    body {{
      font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
      background: #f5f5f5;
      display: flex;
      align-items: center;
      justify-content: center;
      min-height: 100vh;
      color: #212121;
    }}
    .card {{
      background: #fff;
      border-radius: 8px;
      box-shadow: 0 2px 8px rgba(0,0,0,.12);
      padding: 48px 40px;
      max-width: 480px;
      width: 100%;
      text-align: center;
    }}
    .icon {{
      font-size: 48px;
      color: {iconColor};
      margin-bottom: 16px;
    }}
    h1 {{
      font-size: 22px;
      font-weight: 600;
      margin-bottom: 12px;
      color: {iconColor};
    }}
    p {{
      font-size: 15px;
      line-height: 1.6;
      color: #555;
    }}
    .footer {{
      margin-top: 32px;
      font-size: 12px;
      color: #aaa;
    }}
  </style>
</head>
<body>
  <div class=""card"">
    <div class=""icon"">{icon}</div>
    <h1>{title}</h1>
    <p>{body}</p>
    <p class=""footer"">{clientId}</p>
  </div>
</body>
</html>";

            return Encoding.UTF8.GetBytes(html);
        }
    }
}
