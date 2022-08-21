using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {

        // [HttpGet]
        // public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        // {
        //     return await this.mediator.Send(new List.Query(), ct);
        // }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken ct)
        {
            return await this.mediator.Send(new List.Query(), ct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await this.mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await this.mediator.Send(new Create.Command {Activity = activity}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditActivity(Guid id, Activity activity)
        {
            activity.Id = id;
            return Ok(await this.mediator.Send(new Edit.Command {Activity = activity}));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await this.mediator.Send(new Delete.Command {Id = id}));
        }

    }
}