using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
  public class Edit
  {
    public class Command : IRequest
    {
      public Activity Activity { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      public DataContext Context { get; set; }
      private readonly IMapper mapper;
      public Handler(DataContext context, IMapper mapper)
      {
        this.mapper = mapper;
        this.Context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var activity = await Context.Activities.FindAsync(request.Activity.Id);

        // ?? if null
        //activity.Title = request.Activity.Title ?? activity.Title;
        mapper.Map(request.Activity, activity);
        
        await Context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}