using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorAddCommand
{
    public class CreatorAddRequest : IRequest<CreatorAddRequestDto>
    {
        public string NickName { get; set; }
        public string ChainId { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Volume { get; set; }
        public int SoldNFts { get; set; }
    }
}
