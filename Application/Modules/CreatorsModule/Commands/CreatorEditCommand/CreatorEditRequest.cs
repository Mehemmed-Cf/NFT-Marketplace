using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.CreatorsModule.Commands.CreatorEditCommand
{
    public class CreatorEditRequest : IRequest
    {
        public int Id { get; set; }
        public string ChainId { get; set; }
        public string NickName { get; set; }
        public string Bio { get; set; }
        public int Followers { get; set; }
        public int Volume { get; set; }
        public int SoldNFts { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
