using Application.Features.Cars.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Cars.Constants.CarsOperationClaims;

namespace Application.Features.Cars.Queries.GetByCaseType;
public class GetByCaseTypeQuery : IRequest<GetListResponse<GetByCaseTypeItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListCars({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetCars";
    public TimeSpan? SlidingExpiration { get; }
    public class GetByCaseTypeQueryHandler : IRequestHandler<GetByCaseTypeQuery, GetListResponse<GetByCaseTypeItemDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetByCaseTypeQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByCaseTypeItemDto>> Handle(GetByCaseTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _carRepository.GetListAsync(
                predicate: car => car.PlateCode == "42dsy81",
                include: car => car.Include(c => c.BrandSerial).ThenInclude(x => x.Parent),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );
            GetListResponse<GetByCaseTypeItemDto> response = _mapper.Map<GetListResponse<GetByCaseTypeItemDto>>(cars);
            return response;
        }
    }
}
