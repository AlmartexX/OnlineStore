using AutoMapper;
using OnlineStore.BLL.DTO;
using OnlineStore.BLL.MappConfigs.Interfaces;
using OnlineStore.DAL.Settings;

namespace OnlineStore.BLL.MappConfigs
{
    public class PaginationSettingsMapper : IPaginationSettingsMapper
    {
        private readonly IMapper _mapper;

        public PaginationSettingsMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PaginationSettings MapToEntity(PaginationSettingsDTO paginationSettingsDto)
        {
            return _mapper.Map<PaginationSettings>(paginationSettingsDto);
        }
    }
}
