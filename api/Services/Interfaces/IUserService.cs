namespace Transporteo.Services.Interfaces
{
    using Transporteo.DTOs.User;

    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(string id);
        Task<UserDto> CreateAsync(UserCreateDto userDto);
        Task<bool> DeleteAsync(string id);
    }

}
