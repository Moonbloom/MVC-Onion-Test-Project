using AutoMapper;
using Core.DomainModel;
using Web;
using Web.Models;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MappingConfig), "Start")]

namespace Web
{
    public class MappingConfig
    {
        public static void Start()
        {
            Mapper.CreateMap<Task, TaskViewModel>().ReverseMap();
        }
    }
}