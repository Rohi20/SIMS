using AutoMapper;
using SIMSWeb.Business.ServiceDTO.SubmissionDTO;
using SIMSWeb.Model.ViewModels.StudentsModels;

namespace SIMSWeb.Business.ServiceDTO.ServiceProfile
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<SubmissionServiceModel, SubmissionViewModel>();
            CreateMap<SubmissionViewModel, SubmissionServiceModel>();
        }
        
    }
}
