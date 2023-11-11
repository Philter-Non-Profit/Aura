using Microsoft.Extensions.Options;
using Philter.Aura.Data.Options;
using Twilio;

namespace Philter.Aura.Web.TwilioSvc;

public sealed class TwilioHelper
{
    private readonly IOptions<TwilioOptions> _options;
    public TwilioHelper(IOptions<TwilioOptions> options)
    {
        _options = options;
        TwilioClient.Init(options.Value.AccountSid, options.Value.AuthToken);
    }
}