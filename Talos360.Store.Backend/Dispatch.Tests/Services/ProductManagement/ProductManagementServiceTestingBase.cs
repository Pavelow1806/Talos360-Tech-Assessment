using Dispatch.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Tests.Services
{
    public class ProductManagementServiceTestingBase
    {
        internal readonly Mock<IDbContext> _mockDbContext = new Mock<IDbContext>();
    }
}
