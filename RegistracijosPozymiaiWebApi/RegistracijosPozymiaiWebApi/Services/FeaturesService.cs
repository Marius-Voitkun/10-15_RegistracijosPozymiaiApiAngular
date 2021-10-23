using AutoMapper;
using RegistracijosPozymiaiWebApi.DAL;
using RegistracijosPozymiaiWebApi.Dtos;
using RegistracijosPozymiaiWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegistracijosPozymiaiWebApi.Services
{
    public class FeaturesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeaturesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FeatureDto>> GetAllAsync()
        {
            var features = await _unitOfWork.Features.GetAllAsync(nameof(Feature.DropDownOptions));

            return _mapper.Map<List<FeatureDto>>(features);
        }
    }
}
