using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SpetoTex.ModelFromDB;

public partial class HeadST : DbContext
{
    public HeadST()
    {
    }

    public HeadST(DbContextOptions<HeadST> options)
        : base(options)
    {
    }

    public virtual DbSet<JobRequest> JobRequests { get; set; }

}
