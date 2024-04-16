using OnlineStore.BLL.DTO;
using OnlineStore.DAL.Settings;

namespace OnlineStore.BLL.MappConfigs.Interfaces
{
    public interface IPaginationSettingsMapper
    {
        PaginationSettings MapToEntity(PaginationSettingsDTO paginationSettings);
    }
}
