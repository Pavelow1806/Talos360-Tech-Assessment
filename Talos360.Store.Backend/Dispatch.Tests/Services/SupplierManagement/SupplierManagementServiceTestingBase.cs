using Dispatch.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dispatch.Tests.Services.SupplierManagement
{
    public class SupplierManagementServiceTestingBase
    {
        internal readonly Mock<IDbContext> _mockDbContext = new Mock<IDbContext>();
    }
}
