using BlazorWasmSessionAuthentication.Domain.Common.Interfaces;

namespace BlazorWasmSessionAuthentication.Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
