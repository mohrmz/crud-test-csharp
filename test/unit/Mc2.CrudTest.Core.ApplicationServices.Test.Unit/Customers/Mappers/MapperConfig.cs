using AutoMapper;
using Mc2.CrudTest.Core.Domain.Customers.Data.Test;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Update;

namespace Mc2.CrudTest.Core.ApplicationServices.Test.Unit.Customers.Mappers;

public class MapperConfig
{
    public static Mapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<FakeCustomer, Customer>();
            cfg.CreateMap<FakeCustomer, CreateCustomerCommand>();
            cfg.CreateMap<FakeCustomer, UpdateCustomerCommand>();
        });
        var mapper = new Mapper(config);
        return mapper;
    }
}
