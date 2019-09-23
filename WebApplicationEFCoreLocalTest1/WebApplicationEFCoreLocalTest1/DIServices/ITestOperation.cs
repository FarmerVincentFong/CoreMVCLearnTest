using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationEFCoreLocalTest1.DIServices
{
    public interface ITestOperation
    {
        Guid OpId { get; }
    }
    //单例服务测试接口
    public interface ITestOperationSingleton : ITestOperation
    {
    }
    //临时服务测试接口
    public interface ITestOperationTransient : ITestOperation
    {
    }
    //范围服务测试接口
    public interface ITestOperationScoped : ITestOperation
    {
    }

    //依赖接口的具体实现
    public class TestOperation : ITestOperationSingleton, ITestOperationTransient, ITestOperationScoped
    {
        private Guid _guid;
        public Guid OpId => _guid;
        public TestOperation()
        {
            this._guid = Guid.NewGuid();
        }

        public TestOperation(Guid guid)
        {
            this._guid = guid;
        }
    }
}
