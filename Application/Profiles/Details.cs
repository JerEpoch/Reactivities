using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class Details
    {
        public class Query : IRequest<Result<Profile>>
        {
            public string Username { get; set; }
        }

    public class Handler : IRequestHandler<Query, Result<Profile>>
    {
    public DataContext Context { get; }
    public IMapper Mapper { get; }
      public Handler(DataContext context, IMapper mapper)
      {
      this.Mapper = mapper;
      this.Context = context;

      }

      public async Task<Result<Profile>> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await Context.Users.ProjectTo<Profile>(Mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(x => x.Username == request.Username);

        return Result<Profile>.Success(user);
      }
    }
  }
}