using AutoMapper;
using BlazorWasmSessionAuthentication.Application.Authentication;
using BlazorWasmSessionAuthentication.Application.Dtos;
using BlazorWasmSessionAuthentication.Application.Interfaces.Repositories;
using MediatR;

namespace BlazorWasmSessionAuthentication.Application.Features.UserFeatures.Queries.ValidateUser
{
    public record ValidateUser(LoginRequest LoginRequest) : IRequest<UserSession>;
    internal class GetAllUsersHandler : IRequestHandler<ValidateUser, UserSession>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserSession?> Handle(ValidateUser query, CancellationToken cancellationToken)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager(_unitOfWork);
            var userSession = await jwtAuthenticationManager.GenerateJwtToken(query.LoginRequest.UserName, query.LoginRequest.Password);
            return userSession;
        }
    }
}
