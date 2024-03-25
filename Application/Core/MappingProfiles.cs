using Application.Activities;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, Activity>();
            CreateMap<Activity, ActivityDto>()
            .ForMember(destinationMember => destinationMember.HostUsername, options => options.MapFrom(source => source.Attendees
            .FirstOrDefault(x => x.IsHost).AppUser.UserName) );
            CreateMap<ActivityAttendee, Profiles.Profile>()
            .ForMember(destinationMember => destinationMember.DisplayName, options => options.MapFrom(source => source.AppUser.DisplayName))
            .ForMember(destinationMember => destinationMember.Username, options => options.MapFrom(source => source.AppUser.UserName))
            .ForMember(destinationMember => destinationMember.Bio, options => options.MapFrom(source => source.AppUser.Bio));
        }
    }
}