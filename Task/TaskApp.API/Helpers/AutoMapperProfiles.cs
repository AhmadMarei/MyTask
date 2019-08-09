using AutoMapper;
using TaskApp.API.Dtos;
using TaskApp.API.Extensions;
using TaskApp.API.Models;

namespace TaskApp.API.Helpers
{
    // i use Profile to organize the mapping configurations 
    public class AutoMapperProfiles:Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<RoomForUpdateDto, Room>();
            // i add to option to test data becuause i didnot have real source of data the first if we want to test with bost man we 
            //can only active(uncomment A) CreateMap<Room, RoomForReturnDto>(); and disActive defaulte(do comment over it) 
            //  run post man and send data of room by your self :

            //   A
            // CreateMap<Room, RoomForReturnDto>();

            // B
            // another option is default only run App and you will see the fake data
            CreateMap<Room, RoomForReturnDto>().ForMember(dest =>dest.Humidity,opt =>opt.ResolveUsing(src =>src.Humidity.getRandomValue(false)))
            .ForMember(dest =>dest.Temperature,opt =>opt.ResolveUsing(src =>src.Temperature.getRandomValue(true)));
        }
    }
}