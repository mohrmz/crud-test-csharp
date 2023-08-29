using Framework.Endpoints.Controllers;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Create;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Delete;
using Mc2.CrudTest.Core.RequestResponse.Customers.Commands.Update;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetById;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.GetByName;
using Mc2.CrudTest.Core.RequestResponse.Customers.Queries.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        #region Commands
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command) => await Create<CreateCustomerCommand, Guid>(command);

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command) => await Edit(command);

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id) => await Delete(new DeleteCustomerCommand() {Id = id });

        #endregion

        #region Queries
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetCustomerByIdQuery query) => await Query<GetCustomerByIdQuery, CustomerDTO?>(query);

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(GetCustomerByNameQuery query) => await Query<GetCustomerByNameQuery, CustomerDTO?>(query);
        #endregion

        #region Methods
        [HttpGet("/Clear")]
        public bool Clear()
        {
            GC.Collect(2);
            return true;
        }
        #endregion
    }
}
