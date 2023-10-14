using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorWasmSessionAuthentication.Application.Dtos;
using BlazorWasmSessionAuthentication.Application.Interfaces.Repositories;
using BlazorWasmSessionAuthentication.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasmSessionAuthentication.Application.Features.UserFeatures.Queries.GetAllUsers
{
    public record GetAllUsers : IRequest<IEnumerable<UserDto>>;
    internal class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsers query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<User>().Entities
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
