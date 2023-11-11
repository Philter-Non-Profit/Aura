using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Philter.Aura.Web.Twilio;

public sealed class TwilioHelper
{
    private readonly IOptions<TwilioOptions> _options;
    public TwilioHelper(IOptions<TwilioOptions> options)
    {
        _options = options;
        TwilioClient.Init(options.Value.AccountSid, options.Value.AuthToken);
    }
}