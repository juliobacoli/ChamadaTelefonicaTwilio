using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

static void Main(string[] args)
{
    string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
    string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

    string callNumerTo = Environment.GetEnvironmentVariable("CALL_NUMBER_TO");
    string callNumerFromTwilio = Environment.GetEnvironmentVariable("CALL_NUMBER_FROM_TWILIO");

    TwilioClient.Init(accountSid, authToken);

    StringBuilder sb = new StringBuilder();

    sb.AppendLine("<Response>");
    sb.AppendLine("<Say language='pt-BR'>");
    sb.AppendLine("Olá, tudo bem?");
    sb.AppendLine("Estou ligando para você para te lembrar de algo importante.");
    sb.AppendLine("Não se esqueça de fazer o backup dos seus arquivos.");
    sb.AppendLine("Tenha um bom dia!");
    sb.AppendLine("<Response>");

    var call = CallResource.Create(
        twiml: sb.ToString(),
        to: new Twilio.Types.PhoneNumber(callNumerTo),
        from: new Twilio.Types.PhoneNumber(callNumerFromTwilio)
    );

    Console.WriteLine(call.Sid);
    Console.WriteLine(call.Uri.ToString());
}
