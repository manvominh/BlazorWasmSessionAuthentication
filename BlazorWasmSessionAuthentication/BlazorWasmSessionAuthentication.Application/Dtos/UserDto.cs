using BlazorWasmSessionAuthentication.Application.Common.Mappings;
using BlazorWasmSessionAuthentication.Domain.Entities;

namespace BlazorWasmSessionAuthentication.Application.Dtos
{
    public class UserDto : IMapFrom<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
