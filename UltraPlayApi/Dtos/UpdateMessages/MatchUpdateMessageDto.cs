using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Data.Models;
using UltraPlayApi.Services.AutoMapper;

namespace UltraPlayApi.Web.Dtos.UpdateMessages
{
    public class MatchUpdateMessageDto : UpdateMessageDto, IMapFrom<MatchUpdateMessage>
    {
    }
}
